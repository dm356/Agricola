using UnityEngine;
using System.Collections;

public class CollectResource : Action {
	private StockResource stock;

	void Start() {
		stock = GetComponent<StockResource>();
	}

	public override void Execute ()
	{
		Supply.AddStock(stock.resource,stock.Count);
		stock.ClearStock();
	}
}
