using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class ResourcePool : Singleton<ResourcePool> {
	
	public GameObject wood;
	public GameObject clay;
	public GameObject reed;
	public GameObject stone;
	public GameObject grain;
	public GameObject vegetable;
	public GameObject sheep;
	public GameObject boar;
	public GameObject cow;
	public GameObject food;
	private Dictionary<Resource.ResourceType,Stack<GameObject>> pool;
	
	// Use this for initialization
	void Start () {
		pool = new Dictionary<Resource.ResourceType, Stack<GameObject>>();
		foreach(Resource.ResourceType resource in Enum.GetValues(typeof(Resource.ResourceType))){
			pool[resource] = new Stack<GameObject>();
		}
	}

	private static int Stock(Resource.ResourceType resource){
		if(Instance.pool.ContainsKey(resource))
			return Instance.pool[resource].Count;
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

	public static GameObject GetResource(Resource.ResourceType resource){
		return GetResource(resource,Vector3.zero,Quaternion.identity);
	}

	public static GameObject GetResource(Resource.ResourceType resource, Vector3 position, Quaternion rotation){
		GameObject token = null;
		if(Stock(resource) > 0){
			token = Instance.pool[resource].Pop();
			token.transform.position = position;
			token.SetActive(true);
		}else{
			GameObject prefab = GetPrefab(resource);
			if(prefab)
				token = Instantiate(prefab) as GameObject;
		}
		return token;
	}

	public static List<GameObject> GetResources(Resource.ResourceType resource, int amount){
		List<GameObject> list = new List<GameObject>();
		for(int i=0;i<amount;i++){
			list.Add(GetResource(resource));
		}
		return list;
	}

	public static void ReturnResource(GameObject token){
		token.SetActive(false);
		Resource resource = token.GetComponent<Resource>();
		if(resource && Instance.pool.ContainsKey(resource.type)){
			Instance.pool[resource.type].Push(token);
		}else{
			Destroy(token);
			Debug.Log("ResourcePool.ReturnResource ERROR: Unrecognized resource.");
		}
	}
}
