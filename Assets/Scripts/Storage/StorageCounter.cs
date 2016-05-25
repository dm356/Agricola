using UnityEngine;
using System.Collections;

public class StorageCounter
{
	private int count = 0;

	public int Count {
		get {
			return count;
		}
		set {
			count = value;
			if (count < 0) {
				count = 0;
				Debug.Log ("Not enough in storage.");
			}
		}
	}
}
