using UnityEngine;
using System.Collections;

public class CollectResource : Action
{
	private StockResource _stock;

	public CollectResource (StockResource stock) : base ()
	{
		_stock = stock;
	}

	public override int ResourceModifier (ResourceType resource)
	{
		int modifier = base.ResourceModifier (resource);
		if (resource == _stock.resource) {
			modifier += _stock.Count;
		}
		return modifier;
	}

	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerAddResources (_stock.resource, _stock.Count);
		_stock.ClearStock ();
	}
}
