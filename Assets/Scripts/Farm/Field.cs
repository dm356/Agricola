﻿using UnityEngine;
using System.Collections;

public class Field : RecursiveStorage
{

	public void SowResource (ResourceType resource, int count)
	{
//		GameObject token;
		for (int i = 0; i < count; i++) {
//			token = Instantiate(ResourceList.GetPrefab(resource)) as GameObject;
			AddStock (PoolManager.GetResource (resource));
		}
	}

	public void HarvestResources ()
	{
		RemoveTokens (1);
	}
}
