using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSupply : AbstractStorage
{

	public GameObject storagePrefab;
	private Dictionary<ResourceType,ResourceStorage> storage;
	public float spacing;

	void Awake ()
	{
		storage = new Dictionary<ResourceType, ResourceStorage> ();
		spawnStorage (ResourceType.Wood, -3f * spacing);
		spawnStorage (ResourceType.Clay, -2f * spacing);
		spawnStorage (ResourceType.Stone, -1f * spacing);
		spawnStorage (ResourceType.Reed, 0f * spacing);
		spawnStorage (ResourceType.Grain, 1f * spacing);
		spawnStorage (ResourceType.Vegetable, 2f * spacing);
		spawnStorage (ResourceType.Food, 3f * spacing);
	}

	void spawnStorage (ResourceType resource, float x)
	{
		GameObject storage_box = Instantiate (storagePrefab, transform.position + Vector3.right * x, transform.rotation) as GameObject;
		storage_box.transform.SetParent (transform);
		ResourceStorage component = storage_box.GetComponent<ResourceStorage> ();
		component.resource = resource;
		if (storage.ContainsKey (resource) && storage [resource]) {
//			ResourcePool.ReturnResource(storage[resource]);
			Destroy (storage [resource]);
		}
		storage [resource] = component;
	}

	public override void AddStock (GameObject token)
	{
		ResourceType resource = token.GetComponent<Resource> ().type;
		if (storage.ContainsKey (resource)) {
			storage [resource].AddStock (token);
		} else {
			PoolManager.ReturnResource (resource, token);
//			Destroy(token);
			Debug.Log ("PlayerSupply.AddStock ERROR: Resource missing");
		}
	}

	public void AddResources (ResourceType resource, int amount)
	{
		if (storage.ContainsKey (resource)) {
			storage [resource].AddStock (amount);
		} else {
			Debug.Log ("PlayerSupply.AddResources ERROR: Resource missing");
		}
	}

	public GameObject PullResource (ResourceType resource)
	{
		if (storage.ContainsKey (resource)) {
			return storage [resource].PullToken ();
		} else {
			Debug.Log ("PlayerSupply.PullResource ERROR: Resource missing");
			return null;
		}
	}

	public List<GameObject> PullResources (ResourceType resource, int amount)
	{
		if (storage.ContainsKey (resource)) {
			return storage [resource].PullTokens (amount);
		} else {
			Debug.Log ("PlayerSupply.PullResources ERROR: Resource missing");
			return null;
		}
	}

	public void RemoveResources (ResourceType resource, int amount)
	{
		if (storage.ContainsKey (resource)) {
			storage [resource].RemoveTokens (amount);
		} else {
			Debug.Log ("PlayerSupply.RemoveResources ERROR: Resource missing");
		}
	}

	public int ResourceCount (ResourceType resource)
	{
		if (storage.ContainsKey (resource)) {
			return storage [resource].Count;
		} else {
//			Debug.Log("PlayerSupply.ResourceCount ERROR: Resource missing");
			return 0;
		}
	}

	public override GameObject PullToken ()
	{
		throw new System.NotImplementedException ();
	}

	public override int Count {
		get {
			throw new System.NotImplementedException ();
		}
	}

	//	void consoleAction (string[] command)
	//	{
	//		if (command.Length < 3) {
	//			Debug.Log ("Insufficient length");
	//		}
	//		if (command [0].Equals ("add", System.StringComparison.Ordinal)) {
	//			try {
	//				int count = int.Parse (command [2]);
	//				switch (command [1]) {
	//				case "wood":
	//					AddResources (ResourceType.Wood, count);
	//					break;
	//				case "clay":
	//					type = ResourceType.Clay;
	//					break;
	//				case "stone":
	//					type = ResourceType.Stone;
	//					break;
	//				case "reed":
	//					break;
	//
	//				}
	//			} catch (System.FormatException) {
	//				Debug.Log ("Improper formatting.");
	//			}
	//		}
	//	}
}
