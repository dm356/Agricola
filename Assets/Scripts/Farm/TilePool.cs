using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilePool : MonoBehaviour
{
	private List<Tile> tile_list;

	void Start ()
	{
		Console.addConsoleFunction ("pool", consoleAction);
	
		tile_list = new List<Tile> ();
		GameObject s;
		Tile tile;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 5; j++) {
				s = PoolManager.GetTile (TileMarkerType.TILE);
				s.transform.SetParent (transform);
				s.transform.position = gridPoint (i, j);
				tile = s.GetComponent<Tile> ();
				tile.X = i;
				tile.Y = j;
				tile.highlight = false;
				tile_list.Add (tile);
			}
		}
	}

	public void PushTile (Tile tile)
	{
		tile_list.Add (tile);
	}

	public Tile PopTile (int row, int col)
	{
		foreach (Tile tile in tile_list) {
			if (tile.matches (row, col)) {
				tile_list.Remove (tile);
				return tile;
			}
		}
		return null;
	}

	bool TileSelected (Tile tile)
	{
		return tile.selected;
	}

	public Tile PopSelectedActive ()
	{
		foreach (Tile tile in tile_list) {
			if (tile.highlight && tile.selected) {
				tile_list.Remove (tile);
				return tile;
			}
		}
		return null;
	}

	public void HighlightAdjacent (List<Tile> other)
	{
		foreach (Tile tile1 in other) {
			foreach (Tile tile2 in tile_list) {
				if (tile1.adjacent (tile2)) {
					tile2.highlight = true;
				}
			}
		}
	}

	public void HighlightAll ()
	{
		foreach (Tile tile in tile_list) {
			tile.highlight = true;
		}
	}

	public void UnhighlightAll ()
	{
		foreach (Tile tile in tile_list) {
			tile.highlight = false;
		}
	}

	public Vector3 gridPoint (int row, int col)
	{
		Vector3 pos = transform.position;
		Vector3 diff = Vector3.zero;
		diff.x = col * transform.lossyScale.x;
		diff.z = row * transform.lossyScale.z;
		return pos + transform.rotation * diff;
	}

	void consoleAction (string[] command)
	{
		if (command [0].Equals ("highlight", System.StringComparison.Ordinal)) {
			foreach (Tile tile in tile_list) {
				tile.highlight = !tile.highlight;
			}
		}
	}
}
