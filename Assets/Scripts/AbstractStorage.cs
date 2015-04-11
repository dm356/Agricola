using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractStorage : MonoBehaviour {

	public abstract int Count{
		get;
	}

	public abstract void AddStock(GameObject token);
	
	public void AddStock(List<GameObject> tokens){
		foreach(GameObject token in tokens){
			AddStock(token);
		}
	}
	
	public abstract GameObject PullToken();
	
	public List<GameObject> PullTokens(int amount){
		List<GameObject> tokens = new List<GameObject>();
		for(int i=0;i<amount;i++){
			tokens.Add(PullToken());
		}
		return tokens;
	}
	
	public List<GameObject> PullAll(){
		List<GameObject> tokens = PullTokens(Count);
		return tokens;
	}
	
	public void RemoveTokens(int amount){
		foreach(GameObject token in PullTokens(amount)){
//			Destroy(token);
			ResourcePool.ReturnResource(token);
		}
	}
	
	public void ClearStock(){
		RemoveTokens(Count);
	}
}
