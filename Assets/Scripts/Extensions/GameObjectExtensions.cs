using UnityEngine;
using System.Collections;

public static class GameObjectExtensions {

	public static void SetLayerRecursively(this GameObject obj, int newLayer){
		obj.layer = newLayer;
		foreach(Transform child in obj.transform){
			child.gameObject.layer = newLayer;
		}
	}
}
