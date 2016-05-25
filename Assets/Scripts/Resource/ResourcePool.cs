using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourcePool : Singleton<ResourcePool>
{
	
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
	private Dictionary<ResourceType,Stack<GameObject>> pool;
	
	// Use this for initialization
	void Awake ()
	{
		pool = new Dictionary<ResourceType, Stack<GameObject>> ();
		foreach (ResourceType resource in System.Enum.GetValues(typeof(ResourceType))) {
			pool [resource] = new Stack<GameObject> ();
		}
	}

	private int Stock (ResourceType resource)
	{
		if (pool.ContainsKey (resource))
			return pool [resource].Count;
		else
			return 0;
	}

	public static GameObject GetPrefab (ResourceType resource)
	{
		switch (resource) {
		case ResourceType.Wood:
			return Instance.wood;
		case ResourceType.Clay:
			return Instance.clay;
		case ResourceType.Reed:
			return Instance.reed;
		case ResourceType.Stone:
			return Instance.stone;
		case ResourceType.Grain:
			return Instance.grain;
		case ResourceType.Vegetable:
			return Instance.vegetable;
		case ResourceType.Sheep:
			return Instance.sheep;
		case ResourceType.Boar:
			return Instance.boar;
		case ResourceType.Cow:
			return Instance.cow;
		case ResourceType.Food:
			return Instance.food;
		}
		return null;
	}

	public static GameObject GetResource (ResourceType resource)
	{
		return GetResource (resource, Vector3.zero, Quaternion.identity);
	}

	public static GameObject GetResource (ResourceType resource, Vector3 position, Quaternion rotation)
	{
		GameObject token = null;
		if (Instance.Stock (resource) > 0) {
			token = Instance.pool [resource].Pop ();
			token.transform.position = position;
			token.SetActive (true);
		} else {
			GameObject prefab = GetPrefab (resource);
			if (prefab)
				token = Instantiate (prefab) as GameObject;
		}
		return token;
	}

	public static List<GameObject> GetResources (ResourceType resource, int amount)
	{
		List<GameObject> list = new List<GameObject> ();
		for (int i = 0; i < amount; i++) {
			list.Add (GetResource (resource));
		}
		return list;
	}

	public static void ReturnResource (GameObject token)
	{
		token.SetActive (false);
		Resource resource = token.GetComponent<Resource> ();
		if (resource && Instance.pool.ContainsKey (resource.type)) {
			Instance.pool [resource.type].Push (token);
		} else {
			Destroy (token);
			Debug.Log ("ResourcePool.ReturnResource ERROR: Unrecognized resource.");
		}
	}
}
