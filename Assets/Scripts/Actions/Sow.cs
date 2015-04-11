﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sow : Action {

	private bool active = false;

	private Dictionary<Resource.ResourceType,int> cost;

	void Awake(){
		cost = new Dictionary<Resource.ResourceType,int>();
	}

	void Update(){
		if(active){
			SetCost();
			foreach(KeyValuePair<Resource.ResourceType,int> pairs in cost){
				Interface.setModifier(pairs.Key,-pairs.Value);
			}
		}
	}

	public override bool Valid {
		get {
			foreach(KeyValuePair<Resource.ResourceType,int> pairs in cost){
				if(PlayerHandler.ActivePlayerResourceCount(pairs.Key) - pairs.Value < 0){
					return false;
				}
			}
			return base.Valid;
		}
	}

	public override void Setup ()
	{
		active = true;
		PlayerInput.ShowCurrentPlayerFarm();
//		PlayerHandler.CurrentPlayerHouse.BuildRooms();
		base.Setup ();
	}

	public override void Execute ()
	{
		foreach(KeyValuePair<Resource.ResourceType,int> pairs in cost){
			PlayerHandler.CurrentPlayerAddResources(pairs.Key,-pairs.Value);
		}
		active = false;
	}

	public override void Cancel ()
	{
//		PlayerHandler.CurrentPlayerHouse.ClearSelectables();
		active = false;
		base.Cancel();
	}
	
	public void SetCost(){
//		cost = Dictionary<Resource.ResourceType,int>();
		cost[PlayerHandler.CurrentPlayerHouse.type] = 5*PlayerHandler.CurrentPlayerHouse.BuildCount;
		cost[Resource.ResourceType.Reed] = 2*PlayerHandler.CurrentPlayerHouse.BuildCount;
	}
}