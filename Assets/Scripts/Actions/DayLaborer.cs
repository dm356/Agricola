﻿using UnityEngine;
using System.Collections;

public class DayLaborer : Action {
	public override void Execute ()
	{
		Supply.AddStock(Resource.ResourceType.Food, 2);
	}
}
