using UnityEngine;
using System.Collections;

public class CollectResource : Action {
	private StockResource stock;

	void Start() {
		stock = GetComponent<StockResource>();
	}

	public override void Execute (Supply playerSupply)
	{
		playerSupply.AddStock(stock.resource.GetComponent<Resource>().type,stock.Count);
		stock.ClearStock();
	}
}
