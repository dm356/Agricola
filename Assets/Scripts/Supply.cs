using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Supply : MonoBehaviour {
	private Dictionary<Resource.ResourceType,int> stock;

//	private List<GameObject> playerTokens;
	public GameObject playerToken;

	// Use this for initialization
	void Start () {
		stock = new Dictionary<Resource.ResourceType, int>();
		foreach(Resource.ResourceType type in Enum.GetValues(typeof(Resource.ResourceType))){
			stock[type] = 0;
		}
//		playerTokens = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject GetPlayerToken(){
//		return playerTokens[index];
		GameObject token = Instantiate(playerToken) as GameObject;
		return token;
	}

	public int CheckStock(Resource.ResourceType resource){
		return stock[resource];
	}

	public void AddStock(Resource.ResourceType resource, int amount){
		stock[resource] += amount;
	}
}
