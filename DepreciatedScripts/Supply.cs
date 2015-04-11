using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Supply : Singleton<Supply> {
//	private Stock stock;
	private int family_size = 0;

//	private List<GameObject> playerTokens;
	public GameObject playerToken;

	public PlayerSupply supply;
	

	public static GameObject GetPlayerToken(){
//		return playerTokens[index];
		GameObject token = Instantiate(Instance.playerToken) as GameObject;
		return token;
	}

	public static int CheckStock(Resource.ResourceType resource){
		return Instance.supply.ResourceCount(resource);
	}

	public static void AddStock(GameObject token){
		Instance.supply.AddStock(token);
	}

	public static void AddStock(List<GameObject> tokens){
		Instance.supply.AddStock(tokens);
	}

	public static void AddStock(Resource.ResourceType resource, int amount){
		Instance.supply.AddResources(resource,amount);
	}
}
