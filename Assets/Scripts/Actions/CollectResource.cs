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
		base.Setup();
	}

	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerAddStock(stock.PullAll());
	}

	public override void RoundSetup ()
	{
		stock.Restock();
	}
}
