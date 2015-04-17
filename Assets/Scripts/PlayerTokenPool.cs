using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class PlayerTokenPool : Singleton<PlayerTokenPool> {
	public List<GameObject> token_prefabs;
	private List<Stack<PlayerToken>> pool;

	void Awake () {
		pool = new Dictionary<int, Stack<PlayerToken>>();
		for(int i=0;i<token_prefabs.Count;i++){
			pool.Add(new Stack<PlayerToken>());
		}
	}

	private static int Stock(int player){
		if(player >=0 && player < Instance.token_prefabs.Count)
			return Instance.pool[player].Count;
		else
			return 0;
	}

	public static GameObject GetPrefab(Resource.ResourceType resource){
		switch(resource){
		case Resource.ResourceType.Wood:
			return Instance.wood;
		case Resource.ResourceType.Clay:
			return Instance.clay;
		case Resource.ResourceType.Reed:
			return Instance.reed;
		case Resource.ResourceType.Stone:
			return Instance.stone;
		case Resource.ResourceType.Grain:
			return Instance.grain;
		case Resource.ResourceType.Vegetable:
			return Instance.vegetable;
		case Resource.ResourceType.Sheep:
			return Instance.sheep;
		case Resource.ResourceType.Boar:
			return Instance.boar;
		case Resource.ResourceType.Cow:
			return Instance.cow;
		case Resource.ResourceType.Food:
			return Instance.food;
		}
		return null;
	}
}
