using UnityEngine;
using System.Collections;

public class ResourceRoundCard : RoundCard {
	public StockResource stock;

	public override void Activate ()
	{
		base.Activate ();
		ReplenishAction replenish = transform.parent.GetComponent<ReplenishAction>();
		if(_active && replenish){
			replenish.resource_cards.Add(stock);
		}
	}
}
