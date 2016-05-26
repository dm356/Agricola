using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSupply : MonoBehaviour
{

	public GameObject storagePrefab;
	private Dictionary<ResourceType,StorageCounter> storage = new Dictionary<ResourceType, StorageCounter> ();
	public float spacing;

	void Start ()
	{
		Console.addConsoleFunction ("supply", consoleAction);
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
		ResourceStack component = storage_box.GetComponent<ResourceStack> ();
		component.type = resource;
		component.AddStackPosition (new Vector3 (1.7f, 0f, -1.6f));
		component.AddStackPosition (new Vector3 (-1.7f, 0f, -1.6f));
		component.AddStackPosition (new Vector3 (0f, 0f, 2f));
//		if (storage.ContainsKey (resource) && storage [resource]) {
////			ResourcePool.ReturnResource(storage[resource]);
//			Destroy (storage [resource]);
//		}
		storage [resource] = new StorageCounter ();
		component.SetCounter (storage [resource]);
	}

	public void AddResources (ResourceType resource, int amount)
	{
		if (storage.ContainsKey (resource)) {
			storage [resource].Count += amount;
		} else {
			Debug.Log ("PlayerSupply.AddResources ERROR: Resource missing");
		}
	}

	public void RemoveResources (ResourceType resource, int amount)
	{
		if (storage.ContainsKey (resource)) {
			storage [resource].Count -= amount;
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

	void consoleAction (string[] command)
	{
		if (command.Length < 3) {
			Debug.Log ("Insufficient length");
		}
		if (command [0].Equals ("add", System.StringComparison.Ordinal)) {
			try {
				int count = int.Parse (command [2]);
				if (count < 0) {
					RemoveResources (Resource.string2Type (command [1]), -count);
				} else {
					AddResources (Resource.string2Type (command [1]), count);
				}
			} catch (System.FormatException) {
				Debug.Log ("Improper formatting.");
			}
		} else if (command [0].Equals ("remove", System.StringComparison.Ordinal)) {
			try {
				int count = int.Parse (command [2]);
				if (count < 0) {
					AddResources (Resource.string2Type (command [1]), -count);
				} else {
					RemoveResources (Resource.string2Type (command [1]), count);
				}
			} catch (System.FormatException) {
				Debug.Log ("Improper formatting.");
			}
		}
	}
}
