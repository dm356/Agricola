using UnityEngine;
using System.Collections;

public class CollectResource : Action {
	private StockResource stock;

	void Start() {
		foreach(Transform child in transform){
			stock = child.GetComponent<StockResource>();
			if(stock)
				break;
		}
	}

	public override void Execute ()
	{
		Supply.AddStock(stock.PullAll());
	}
}
