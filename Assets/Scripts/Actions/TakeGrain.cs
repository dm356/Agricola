using UnityEngine;
using System.Collections;

public class TakeGrain : Action {
	public override void Execute (Supply playerSupply)
	{
		playerSupply.AddStock(Resource.ResourceType.Grain,1);
	}
}
