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
	private Dictionary<Resource.ResourceType,Stack<Resource>> pool;
	
	// Use this for initialization
	void Awake () {
		pool = new Dictionary<Resource.ResourceType, Stack<Resource>>();
		foreach(Resource.ResourceType resource in Enum.GetValues(typeof(Resource.ResourceType))){
			pool[resource] = new Stack<Resource>();
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

	public static Resource GetResource(Resource.ResourceType resource){
		return GetResource(resource,Vector3.zero,Quaternion.identity);
	}

	public static Resource GetResource(Resource.ResourceType type, Vector3 position, Quaternion rotation){
		GameObject token = null;
		Resource resource = null;
		if(Stock(type) > 0){
			resource = Instance.pool[type].Pop();
			token = resource.gameObject;
			token.transform.position = position;
			token.transform.rotation = rotation;
			token.SetActive(true);
		}else{
			GameObject prefab = GetPrefab(type);
			if(prefab){
				token = Instantiate(prefab, position, rotation) as GameObject;
				resource = token.GetComponent<Resource>();
			}
		}

		return resource;
	}

	public static List<Resource> GetResources(Resource.ResourceType type, int amount){
		List<GameObject> list = new List<GameObject>();
		for(int i=0;i<amount;i++){
			list.Add(GetResource(type));
		}
		return list;
	}

	public static void ReturnResource(Resource resource){
		resource.gameObject.SetActive(false);
		if(Instance.pool.ContainsKey(resource.type)){
			Instance.pool[resource.type].Push(resource);
		}else{
//			Destroy(resource.gameObject);
			Debug.Log("ResourcePool.ReturnResource ERROR: Unrecognized resource.");
		}
	}
}
