using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecursiveStorage<T> : AbstractStorage<T> {

	private List<AbstractStorage<T>> storage_list;

	public override int Count{
		get{
			int n = 0;
			foreach(AbstractStorage<T> stack in storage_list){
				n += stack.Count;
			}
			return n;
		}
	}
	
	void Awake () {
		storage_list = new List<AbstractStorage<T>>();
		AbstractStorage<T> storage;
		foreach(Transform child in transform){
			storage = child.GetComponent<AbstractStorage<T>>();
			if(storage){
				storage_list.Add(storage);
			}
		}
	}
	
	public override void AddStock(T item){
		AbstractStorage<T> min_storage = null;
		int min_count = 1000000;
		foreach(AbstractStorage<T> storage in storage_list){
			if(storage.Count < min_count){
				min_count = storage.Count;
				min_storage = storage;
			}
		}
		min_storage.AddStock(item);
	}

	public override void RemoveStock ()
	{
		AbstractStorage<T> max_storage = null;
		int max_count = 0;
		foreach(AbstractStorage<T> storage in storage_list){
			if(storage.Count > max_count){
				max_count = storage.Count;
				max_storage = storage;
			}
		}
		
		if(max_storage){
			max_storage.RemoveStock();
		}else{
			Debug.Log("RecursiveStorage.RemoveStock ERROR: No stock left");
//			return null;
		}
	}
}
