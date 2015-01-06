using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TokenStack : MonoBehaviour {

	private List<GameObject> stock;

	public int Count{
		get{
			return stock.Count;
		}
	}

	void Awake () {
		stock = new List<GameObject>();
	}
	
	public void AddStock(GameObject token){
		float height = transform.position.y;
		foreach(GameObject item in stock){
			height = Mathf.Max(item.transform.position.y + 2f*item.collider.bounds.extents.y,height);
		}
		height += 0.5f;

		token.transform.position = transform.position + transform.up*height;
		token.transform.rotation = transform.rotation;
		token.transform.parent = transform;
		stock.Add(token);
	}
	
	public void AddStock(List<GameObject> tokens){
		foreach(GameObject token in tokens){
			AddStock(token);
		}
	}
	
	public GameObject PullToken(){
		GameObject token = stock[Count-1];
		stock.RemoveAt(Count-1);
		return token;
	}
	
	public List<GameObject> PullTokens(int amount){
		int start = Mathf.Max(0, Count-1-amount);
		List<GameObject> tokens = stock.GetRange(start,amount);
		stock.RemoveRange(start,amount);
		return tokens;
	}
	
	public List<GameObject> PullAll(){
		List<GameObject> tokens = PullTokens(Count);
		return tokens;
	}
	
	public void RemoveTokens(int amount){
		foreach(GameObject token in PullTokens(amount)){
			Destroy(token);
		}
	}
	
	public void ClearStock(){
		foreach(GameObject item in stock){
			Destroy(item);
		}
		stock.Clear();
	}
}
