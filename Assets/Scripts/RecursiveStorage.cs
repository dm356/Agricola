using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecursiveStorage : AbstractStorage {

	private List<AbstractStorage> storage_list;
	
	public override int Count{
		get{
			int n = 0;
			foreach(AbstractStorage stack in storage_list){
				n += stack.Count;
			}
			return n;
		}
	}
	
	void Start () {
		storage_list = new List<AbstractStorage>();
		AbstractStorage storage;
		foreach(Transform child in transform){
			storage = child.GetComponent<AbstractStorage>();
			if(storage){
				storage_list.Add(storage);
			}
		}
	}
	
	public override void AddStock(GameObject token){
		AbstractStorage min_storage = null;
		int min_count = 1000000;
		foreach(AbstractStorage storage in storage_list){
			if(storage.Count < min_count){
				min_count = storage.Count;
				min_storage = storage;
			}
		}
		min_storage.AddStock(token);
	}
	
	public override GameObject PullToken(){
		AbstractStorage max_storage = null;
		int max_count = 0;
		foreach(AbstractStorage storage in storage_list){
			if(storage.Count > max_count){
				max_count = storage.Count;
				max_storage = storage;
			}
		}
		
		if(max_storage){
			return max_storage.PullToken();
		}else{
			Debug.Log("TokenStack.PullToken ERROR: No tokens left");
			return null;
		}
	}
}
