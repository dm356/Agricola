using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbstractStack<T> : AbstractStorage<T> {

	protected Stack<T> stock;

	public override int Count{
		get{
			return stock.Count;
		}
	}

	void Awake () {
		stock = new List<T>();
	}
	
	public override void AddStock(T item){
//		float height = transform.position.y;
//		foreach(GameObject item in stock){
//			height = Mathf.Max(item.transform.position.y + 2f*item.collider.bounds.extents.y,height);
//		}
//		height += 0.5f;
//
//		token.transform.position = transform.position + transform.up*height;
//		token.transform.rotation = transform.rotation;
//		token.transform.parent = transform;
		stock.Push(item);
	}
}
