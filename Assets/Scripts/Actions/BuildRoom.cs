using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildRoom : Action
{

	public int limit = 15;

	private bool _active = false;

	private Dictionary<ResourceType,int> cost;

	void Awake ()
	{
		cost = new Dictionary<ResourceType,int> ();
	}

	void Update ()
	{
		if (_active) {
			SetCost ();
			foreach (KeyValuePair<ResourceType,int> pairs in cost) {
				Interface.setModifier (pairs.Key, -pairs.Value);
			}
		}
	}

	//	public override bool Valid {
	//		get {
	//			foreach(KeyValuePair<Resource.ResourceType,int> pairs in cost){
	//				if(PlayerHandler.ActivePlayerResourceCount(pairs.Key) - pairs.Value < 0){
	//					return false;
	//				}
	//			}
	//			House house = PlayerHandler.CurrentPlayerHouse;
	//			if(house.grid.CheckConnectivity(Tile.TileType.Room,Tile.TileType.None) && house.BuildCount <= limit){
	//				return base.Valid;
	//			}
	//			return false;
	//		}
	//	}

	//	public override void Setup ()
	//	{
	//		_active = true;
	//		PlayerInput.ShowCurrentPlayerFarm();
	//		PlayerHandler.CurrentPlayerHouse.BuildRooms();
	//		base.Setup ();
	//	}

	public override void Execute ()
	{
//		PlayerHandler.CurrentPlayerFarm.house.SetRooms ();
		foreach (KeyValuePair<ResourceType,int> pairs in cost) {
			PlayerHandler.CurrentPlayerAddResources (pairs.Key, -pairs.Value);
		}
		_active = false;
	}

	//	public override void Cancel ()
	//	{
	//		PlayerHandler.CurrentPlayerHouse.ClearSelectables();
	//		_active = false;
	//		base.Cancel();
	//	}

	public void SetCost ()
	{
//		cost = Dictionary<ResourceType,int>();
//		cost [PlayerHandler.CurrentPlayerFarm.house.type] = 5 * PlayerHandler.CurrentPlayerFarm.house.BuildCount;
//		cost [ResourceType.Reed] = 2 * PlayerHandler.CurrentPlayerFarm.house.BuildCount;
	}
}
