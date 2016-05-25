using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFarm : MonoBehaviour
{
	public Transform farm_view;

	public PlayerSupply supply;

	private TilePool tile_pool;
	private House house;
	private FieldHandler field;

	void BuildTilePool ()
	{
		GameObject s = new GameObject ();
		SetStartPosition (s);
		s.name = "TilePool";
		tile_pool = s.AddComponent<TilePool> ();
		s.AddComponent<GridGizmo> ();
	}

	void BuildHouse ()
	{
		GameObject s = new GameObject ();
		SetStartPosition (s);
		s.name = "House";
		house = s.AddComponent<House> ();
		house.SetTilePool (tile_pool);
	}

	void BuildField ()
	{
		GameObject s = new GameObject ();
		SetStartPosition (s);
		s.name = "Field";
		field = s.AddComponent<FieldHandler> ();
		field.SetTilePool (tile_pool);
	}

	void Awake ()
	{
		BuildTilePool ();
		BuildHouse ();
		BuildField ();
	}

	public int FamilyCount ()
	{
		return 0;
//		return house.Count;
	}

	public GameObject TakeFamily ()
	{
		if (FamilyCount () > 0) {
			return null;
//			return house.PullToken ();
		} else {
			return null;
		}
	}

	public void AddFamily (GameObject token)
	{
//		house.AddStock (token);
	}

	public int ResourceCount (ResourceType resource)
	{
		return supply.ResourceCount (resource);
	}

	public void AddResources (List<GameObject> tokens)
	{
		supply.AddStock (tokens);
	}

	public void AddResources (ResourceType resource, int amount)
	{
		supply.AddResources (resource, amount);
	}

	public void HighlightSpace (bool on, int row, int col)
	{
//		highlight_grid.Highlight (on, row, col);
	}

	void SetStartPosition (GameObject obj)
	{
		obj.transform.position = new Vector3 (-22.6107f, 0.2f, -17.38521f);
		obj.transform.SetParent (transform, false);
		obj.transform.localScale = new Vector3 (12.5f, 1f, 12.5f);
	}
}
