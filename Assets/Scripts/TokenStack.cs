using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TokenStack : AbstractStorage {

	private List<GameObject> stock;

	public override int Count{
		get{
			return stock.Count;
		}
	}

	void Awake () {
		stock = new List<GameObject>();
	}
	
	public override void AddStock(GameObject token){
		float height = transform.position.y;
		foreach(GameObject item in stock){
			height = Mathf.Max(item.transform.position.y + 2f*item.GetComponent<Collider>().bounds.extents.y,height);
		}
		height += 0.5f;

		token.transform.position = transform.position + transform.up*height;
		token.transform.rotation = transform.rotation;
		token.transform.parent = transform;
		stock.Add(token);
	}
	
	public override GameObject PullToken(){
		GameObject token = stock[Count-1];
		stock.RemoveAt(Count-1);
		return token;
	}
}
