using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Supply : Singleton<Supply> {
	private Dictionary<Resource.ResourceType,ResourceStorage> storage;

//	private Stock stock;
	private int family_size = 0;

//	private List<GameObject> playerTokens;
	public GameObject playerToken;

	// Use this for initialization
	void Start () {
		storage = new Dictionary<Resource.ResourceType, ResourceStorage>();
		ResourceStorage s;
		foreach(Transform child in transform){
			s = child.GetComponent<ResourceStorage>();
			if(s){
				storage[s.resource] = s;
			}
		}
	}

	public static GameObject GetPlayerToken(){
//		return playerTokens[index];
		GameObject token = Instantiate(Instance.playerToken) as GameObject;
		return token;
	}

	public static int CheckStock(Resource.ResourceType resource){
		if(Instance.storage.ContainsKey(resource)){
			return Instance.storage[resource].Count;
		}else{
//			Debug.Log("Supply.CheckStock ERROR: Resource missing");
			return 0;
		}
	}

	public static void AddStock(Resource.ResourceType resource, int amount){
		if(Instance.storage.ContainsKey(resource)){
			Instance.storage[resource].AddStock(amount);
		}else{
			Debug.Log("Supply.AddStock ERROR: Resource missing");
		}
	}
	
	public static void AddStock(GameObject token){
		Resource.ResourceType resource = token.GetComponent<Resource>().type;
		if(Instance.storage.ContainsKey(resource)){
			Instance.storage[resource].AddStock(token);
		}else{
			Debug.Log("Supply.AddStock ERROR: Resource missing");
		}
	}

	public static void AddStock(List<GameObject> tokens){
		foreach(GameObject token in tokens){
			AddStock(token);
		}
	}
}
