﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ResourceType
{
	Wood,
	Clay,
	Reed,
	Stone,
	Grain,
	Vegetable,
	Sheep,
	Boar,
	Cow,
	Food}
;

public class Resource : MonoBehaviour
{
	public ResourceType type;

	public static System.Collections.Generic.IEnumerable<ResourceType> TypeIterator ()
	{
		yield return ResourceType.Wood;
		yield return ResourceType.Clay;
		yield return ResourceType.Reed;
		yield return ResourceType.Stone;
		yield return ResourceType.Grain;
		yield return ResourceType.Vegetable;
		yield return ResourceType.Sheep;
		yield return ResourceType.Boar;
		yield return ResourceType.Cow;
		yield return ResourceType.Food;
	}

	public static int numResources {
		get {
			return 10;
		}
	}

	public static bool IsAnimal (ResourceType type)
	{
		return type == ResourceType.Boar || type == ResourceType.Cow || type == ResourceType.Sheep;
	}
}