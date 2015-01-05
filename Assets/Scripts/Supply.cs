using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Supply : Singleton<Supply> {
	public List<ResourceStorage> storage;

//	private Stock stock;
	private int family_size = 0;

//	private List<GameObject> playerTokens;
	public GameObject playerToken;

	// Use this for initialization
	void Awake () {
//		stock = new Stock();
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
		foreach(ResourceStorage bank in Instance.storage){
			if(bank.resource == resource){
				return bank.Count;
			}
		}
		return 0;
	}

	public static void AddStock(Resource.ResourceType resource, int amount){
		foreach(ResourceStorage bank in Instance.storage){
			if(bank.resource == resource){
				bank.AddStock(amount);
			}
		}
	}

	public static void AddStock(Resource.ResourceType resource, List<GameObject> tokens){
		foreach(ResourceStorage bank in Instance.storage){
			if(bank.resource == resource){
				bank.AddStock(tokens);
			}
		}
	}
}
