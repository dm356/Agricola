using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Supply : Singleton<Supply> {
	private Dictionary<Resource.ResourceType,int> stock;
	private int family_size = 0;

//	private List<GameObject> playerTokens;
	public GameObject playerToken;

	// Use this for initialization
	void Awake () {
		stock = new Dictionary<Resource.ResourceType, int>();
		foreach(Resource.ResourceType type in Enum.GetValues(typeof(Resource.ResourceType))){
			stock[type] = 0;
		}
//		playerTokens = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject GetPlayerToken(){
//		return playerTokens[index];
		GameObject token = Instantiate(Instance.playerToken) as GameObject;
		return token;
	}

	public static int CheckStock(Resource.ResourceType resource){
		return Instance.stock[resource];
	}

	public static void AddStock(Resource.ResourceType resource, int amount){
		Instance.stock[resource] += amount;
	}
}
