using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class ResourcePool_bak : Singleton<ResourcePool_bak>
{
	
	//	public GameObject wood;
	//	public GameObject clay;
	//	public GameObject reed;
	//	public GameObject stone;
	//	public GameObject grain;
	//	public GameObject vegetable;
	//	public GameObject sheep;
	//	public GameObject boar;
	//	public GameObject cow;
	//	public GameObject food;
	public List<GameObject> prefabs;
	private Dictionary<ResourceType,AbstractPool<Resource>> pools;
	
	// Use this for initialization
	void Awake ()
	{
		pools = new Dictionary<ResourceType, AbstractPool<Resource>> ();
		Resource resource;
		foreach (GameObject obj in prefabs) {
			resource = obj.GetComponent<Resource> ();
			if (!pools.ContainsKey (resource.type)) {
				pools [resource.type] = new AbstractPool<Resource> (obj);
			}
		}
//		foreach(ResourceType resource in Enum.GetValues(typeof(ResourceType))){
//			pools[resource] = new AbstractPool<Resource>();
//		}
	}

	//	private static int Stock(ResourceType resource){
	//		if(Instance.pools.ContainsKey(resource))
	//			return Instance.pools[resource].Count;
	//		else
	//			return 0;
	//	}

	public static GameObject GetPrefab (ResourceType resource)
	{
		return Instance.pools [resource].Prefab;
	}
	
	//	public static GameObject GetPrefab(ResourceType resource){
	//		switch(resource){
	//			case ResourceType.Wood:
	//				return Instance.wood;
	//			case ResourceType.Clay:
	//				return Instance.clay;
	//			case ResourceType.Reed:
	//				return Instance.reed;
	//			case ResourceType.Stone:
	//				return Instance.stone;
	//			case ResourceType.Grain:
	//				return Instance.grain;
	//			case ResourceType.Vegetable:
	//				return Instance.vegetable;
	//			case ResourceType.Sheep:
	//				return Instance.sheep;
	//			case ResourceType.Boar:
	//				return Instance.boar;
	//			case ResourceType.Cow:
	//				return Instance.cow;
	//			case ResourceType.Food:
	//				return Instance.food;
	//		}
	//		return null;
	//	}

	public static Resource GetResource (ResourceType type)
	{
		Resource resource = Instance.pools [type].GetItem ();
		resource.gameObject.SetActive (true);
		return resource;
//		return GetResource(resource,Vector3.zero,Quaternion.identity);
	}

	public static Resource GetResource (ResourceType type, Vector3 position, Quaternion rotation)
	{
		Resource resource = GetResource (type);
		resource.transform.position = position;
		resource.transform.rotation = rotation;
//		GameObject token = null;
//		Resource resource = null;
//		if(Stock(type) > 0){
//			resource = Instance.pools[type].Pop();
//			token = resource.gameObject;
//			token.transform.position = position;
//			token.transform.rotation = rotation;
//			token.SetActive(true);
//		}else{
//			GameObject prefab = GetPrefab(type);
//			if(prefab){
//				token = Instantiate(prefab, position, rotation) as GameObject;
//				resource = token.GetComponent<Resource>();
//			}
//		}

		return resource;
	}

	public static List<Resource> GetResources (ResourceType type, int amount)
	{
		List<Resource> list = new List<Resource> ();
		for (int i = 0; i < amount; i++) {
			list.Add (GetResource (type));
		}
		return list;
	}

	public static void ReturnResource (Resource resource)
	{
		resource.gameObject.SetActive (false);
		if (Instance.pools.ContainsKey (resource.type)) {
			Instance.pools [resource.type].ReturnItem (resource);
		} else {
//			Destroy(resource.gameObject);
			Debug.Log ("ResourcePool.ReturnResource ERROR: Unrecognized resource.");
		}
	}
}
