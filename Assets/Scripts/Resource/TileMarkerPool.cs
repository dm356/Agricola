using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileMarkerPool : Singleton<TileMarkerPool>
{
	public GameObject room;
	public GameObject field;
	public GameObject pasture;

	private Dictionary<TileMarkerType,Stack<GameObject>> pool;

	// Use this for initialization
	void Awake ()
	{
		pool = new Dictionary<TileMarkerType, Stack<GameObject>> ();
		foreach (TileMarkerType resource in System.Enum.GetValues(typeof(TileMarkerType))) {
			pool [resource] = new Stack<GameObject> ();
		}
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public static GameObject GetPrefab (TileMarkerType type)
	{
		switch (type) {
		case TileMarkerType.ROOM:
			return Instance.room;
		case TileMarkerType.FIELD:
			return Instance.field;
		case TileMarkerType.PASTURE:
			return Instance.pasture;
		}
		return null;
	}

	private int Stock (TileMarkerType type)
	{
		if (pool.ContainsKey (type))
			return pool [type].Count;
		else
			return 0;
	}

	public static GameObject GetTile (TileMarkerType type)
	{
		GameObject token = null;
		if (Instance.Stock (type) > 0) {
			token = Instance.pool [type].Pop ();
			token.SetActive (true);
		} else {
			GameObject prefab = GetPrefab (type);
			if (prefab)
				token = Instantiate (prefab) as GameObject;
		}
		return token;
	}

	public static void ReturnRoom (GameObject token)
	{
		token.SetActive (false);
//		if (resource && Instance.pool.ContainsKey (resource.type)) {
//			Instance.pool [resource.type].Push (token);
//		} else {
//			Destroy (token);
//			Debug.Log ("ResourcePool.ReturnResource ERROR: Unrecognized resource.");
//		}
	}
}
