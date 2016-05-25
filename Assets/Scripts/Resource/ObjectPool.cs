using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	public GameObject prefab;
	private Stack<GameObject> pool;

	void Awake ()
	{
		pool = new Stack<GameObject> ();
	}

	public GameObject GetObject ()
	{
		GameObject token;
		if (pool.Count > 0) {
			token = pool.Pop ();
			token.SetActive (true);
		} else {
			token = Instantiate (prefab) as GameObject;
		}
		return token;
	}

	public List<GameObject> GetObjects (int count)
	{
		List<GameObject> objects = new List<GameObject> ();
		for (int i = 0; i < count; i++) {
			objects.Add (GetObject ());
		}
		return objects;
	}

	public void ReturnObject (GameObject token)
	{
		token.SetActive (false);
		token.transform.SetParent (transform);
		pool.Push (token);
	}
}
