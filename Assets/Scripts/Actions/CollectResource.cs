using UnityEngine;
using System.Collections;

public class CollectResource : Action {
	public StockResource stock;

//	void Start() {
//		foreach(Transform child in transform){
//			stock = child.GetComponent<StockResource>();
//			if(stock)
//				break;
//		}
//	}

	public override void Setup ()
	{
		Interface.setModifier(stock.resource,stock.Count);
	}

	public override void Execute ()
	{
		Supply.AddStock(stock.PullAll());
	}
}
