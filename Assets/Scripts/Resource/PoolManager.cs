using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileMarkerType
{
	TILE,
	ROOM,
	FIELD,
	PASTURE}
;

public class PoolManager : Singleton<PoolManager>
{
	public GameObject wood;
	public GameObject clay;
	public GameObject reed;
	public GameObject stone;
	public GameObject grain;
	public GameObject vegetable;
	public GameObject sheep;
	public GameObject boar;
	public GameObject cow;
	public GameObject food;

	public GameObject tile;
	public GameObject room;
	public GameObject field;
	public GameObject pasture;

	private Dictionary<ResourceType,ObjectPool> resource_pools;
	private Dictionary<TileMarkerType,ObjectPool> tile_pools;


	// Use this for initialization
	void Awake ()
	{
		resource_pools = new Dictionary<ResourceType, ObjectPool> ();
		foreach (ResourceType resource in System.Enum.GetValues(typeof(ResourceType))) {
			resource_pools [resource] = gameObject.AddComponent <ObjectPool> ();
			switch (resource) {
			case ResourceType.Wood:
				resource_pools [resource].prefab = wood;
				break;
			case ResourceType.Clay:
				resource_pools [resource].prefab = clay;
				break;
			case ResourceType.Reed:
				resource_pools [resource].prefab = reed;
				break;
			case ResourceType.Stone:
				resource_pools [resource].prefab = stone;
				break;
			case ResourceType.Grain:
				resource_pools [resource].prefab = grain;
				break;
			case ResourceType.Vegetable:
				resource_pools [resource].prefab = vegetable;
				break;
			case ResourceType.Sheep:
				resource_pools [resource].prefab = sheep;
				break;
			case ResourceType.Boar:
				resource_pools [resource].prefab = boar;
				break;
			case ResourceType.Cow:
				resource_pools [resource].prefab = cow;
				break;
			case ResourceType.Food:
				resource_pools [resource].prefab = food;
				break;
			}
		}
		// At some point make the above look like the below
		tile_pools = new Dictionary<TileMarkerType, ObjectPool> ();
		tile_pools [TileMarkerType.TILE] = gameObject.AddComponent <ObjectPool> ();
		tile_pools [TileMarkerType.TILE].prefab = tile;
		tile_pools [TileMarkerType.FIELD] = gameObject.AddComponent <ObjectPool> ();
		tile_pools [TileMarkerType.FIELD].prefab = field;
		tile_pools [TileMarkerType.PASTURE] = gameObject.AddComponent <ObjectPool> ();
		tile_pools [TileMarkerType.PASTURE].prefab = pasture;
		tile_pools [TileMarkerType.ROOM] = gameObject.AddComponent <ObjectPool> ();
		tile_pools [TileMarkerType.ROOM].prefab = room;
	}

	public static GameObject GetResource (ResourceType resource)
	{
		return Instance.resource_pools [resource].GetObject ();
	}

	public static List<GameObject> GetResources (ResourceType resource, int count)
	{
		return Instance.resource_pools [resource].GetObjects (count);
	}

	public static void ReturnResource (ResourceType resource, GameObject obj)
	{
		Instance.resource_pools [resource].ReturnObject (obj);
	}

	public static GameObject GetTile (TileMarkerType tile)
	{
		return Instance.tile_pools [tile].GetObject ();
	}

	public static void ReturnTile (TileMarkerType tile, GameObject obj)
	{
		Instance.tile_pools [tile].ReturnObject (obj);
	}
}
