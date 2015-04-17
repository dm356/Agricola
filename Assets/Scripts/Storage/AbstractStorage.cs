using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractStorage<T> : MonoBehaviour {

	public abstract int Count{
		get;
	}

	public abstract void AddStock(T item);
	
	public void AddStock(List<T> items){
		foreach(T item in items){
			AddStock(item);
		}
	}
	
//	public abstract GameObject PullToken();
//	
//	public List<GameObject> PullTokens(int amount){
//		List<GameObject> tokens = new List<GameObject>();
//		for(int i=0;i<amount;i++){
//			tokens.Add(PullToken());
//		}
//		return tokens;
//	}
//	
//	public List<GameObject> PullAll(){
//		List<GameObject> tokens = PullTokens(Count);
//		return tokens;
//	}
	public abstract void RemoveStock();
	
	public void RemoveStock(int amount){
		for(int i=0;i<Count;i++){
			RemoveStock();
		}
	}

	public void ClearStock(){
		RemoveStock(Count);
	}
}
