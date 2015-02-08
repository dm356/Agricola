using UnityEngine;
using System.Collections;

public class DayLaborer : Action {
	public override void Setup ()
	{
		Interface.setModifier(Resource.ResourceType.Food,2);
	}

	public override void Execute ()
	{
		Supply.AddStock(Resource.ResourceType.Food, 2);
	}
}
