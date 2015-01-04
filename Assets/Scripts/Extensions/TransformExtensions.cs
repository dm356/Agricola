using UnityEngine;
using System.Collections;

public static class TransformExtensions {
	public static void SetParent(this Transform child, Transform parent){
		Vector3 pos = child.position;
		Quaternion rotation = child.rotation;
		Vector3 scale = child.localScale;

		child.parent = parent;
		child.localPosition = pos;
		child.localRotation = rotation;
		child.localScale = scale;
	}
}
