using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSupply : AbstractStorage<Resource> {

	public GameObject storagePrefab;
	private Dictionary<Resource.ResourceType,ResourceStorage> storage;
	public float spacing;

	void Awake(){
		storage = new Dictionary<Resource.ResourceType, ResourceStorage>();
		spawnStorage(Resource.ResourceType.Wood,-3f*spacing);
		spawnStorage(Resource.ResourceType.Clay,-2f*spacing);
		spawnStorage(Resource.ResourceType.Stone,-1f*spacing);
		spawnStorage(Resource.ResourceType.Reed,0f*spacing);
		spawnStorage(Resource.ResourceType.Grain,1f*spacing);
		spawnStorage(Resource.ResourceType.Vegetable,2f*spacing);
		spawnStorage(Resource.ResourceType.Food,3f*spacing);
	}

	void spawnStorage(Resource.ResourceType resource, float x){
		GameObject storage_box = Instantiate(storagePrefab,transform.position + Vector3.right*x,transform.rotation) as GameObject;
		storage_box.transform.parent = transform;
		ResourceStorage component = storage_box.GetComponent<ResourceStorage>();
		component.resource = resource;
		if(storage.ContainsKey(resource) && storage[resource]){
//			ResourcePool.ReturnResource(storage[resource]);
			Destroy(storage[resource]);
		}
		storage[resource] = component;
	}

//	public override void AddStock (GameObject token)
//	{
//		Resource.ResourceType resource = token.GetComponent<Resource>().type;
//		if(storage.ContainsKey(resource)){
//			storage[resource].AddStock(token);
//		}else{
//			ResourcePool.ReturnResource(token);
////			Destroy(token);
//			Debug.Log("PlayerSupply.AddStock ERROR: Resource missing");
//		}
//	}

	public override void AddStock (Resource item)
	{
		if(storage.ContainsKey(item.type)){
			storage[item.type].AddStock(item);
		}else{
			ResourcePool.ReturnResource(item);
//			Destroy(token);
			Debug.Log("PlayerSupply.AddStock ERROR: Resource missing");
		}
	}

	public void AddResources(Resource.ResourceType resource, int amount){
		if(storage.ContainsKey(resource)){
			storage[resource].AddStock(amount);
		}else{
			Debug.Log("PlayerSupply.AddResources ERROR: Resource missing");
		}
	}

//	public GameObject PullResource(Resource.ResourceType resource){
//		if(storage.ContainsKey(resource)){
//			return storage[resource].PullToken();
//		}else{
//			Debug.Log("PlayerSupply.PullResource ERROR: Resource missing");
//			return null;
//		}
//	}
	
//	public List<GameObject> PullResources(Resource.ResourceType resource, int amount){
//		if(storage.ContainsKey(resource)){
//			return storage[resource].PullTokens(amount);
//		}else{
//			Debug.Log("PlayerSupply.PullResources ERROR: Resource missing");
//			return null;
//		}
//	}
	
	public void RemoveResources(Resource.ResourceType resource, int amount){
		if(storage.ContainsKey(resource)){
			storage[resource].RemoveStock(amount);
		}else{
			Debug.Log("PlayerSupply.RemoveResources ERROR: Resource missing");
		}
	}

	public int ResourceCount(Resource.ResourceType resource){
		if(storage.ContainsKey(resource)){
			return storage[resource].Count;
		}else{
//			Debug.Log("PlayerSupply.ResourceCount ERROR: Resource missing");
			return 0;
		}
	}

	public override void RemoveStock ()
	{
		throw new System.NotImplementedException ();
	}

//	public override GameObject PullToken ()
//	{
//		throw new System.NotImplementedException ();
//	}

	public override int Count {
		get {
			throw new System.NotImplementedException ();
		}
	}
}
