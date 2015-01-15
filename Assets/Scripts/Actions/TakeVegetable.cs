using UnityEngine;
using System.Collections;

public class TakeVegetable : Action {
	public override void Execute ()
	{
		Supply.AddStock(Resource.ResourceType.Vegetable,1);
	}
}
