using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileHandler : MonoBehaviour
{
	protected TilePool tile_pool;
	protected List<Tile> tile_list;
	protected List<Tile> pending_claims;

	void Awake ()
	{
		tile_list = new List<Tile> ();
		pending_claims = new List<Tile> ();
	}

	public void SetTilePool (TilePool pool)
	{
		tile_pool = pool;
	}

	protected void InitializeSelectable ()
	{
		if (tile_list.Count < 1)
			tile_pool.HighlightAll ();
		else
			tile_pool.HighlightAdjacent (tile_list);
	}

	protected void UpdateSelectable ()
	{

		while (ClaimSelectedActive ()) {
//				Debug.Log ("Claimed tile.");
		}
		foreach (Tile tile in pending_claims) {
			if (tile.selected) {
				AbandonClaim (tile);
				tile.DoneProcessing ();
				break;
			}
		}
		tile_pool.UnhighlightAll ();
		if (tile_list.Count < 1 && pending_claims.Count < 1) {
			tile_pool.HighlightAll ();
		} else {
			tile_pool.HighlightAdjacent (tile_list);
			tile_pool.HighlightAdjacent (pending_claims);
		}
	}

	public virtual void StakeClaim (Tile tile)
	{
		pending_claims.Add (tile);
	}

	protected bool ClaimIndexed (int row, int col)
	{
		Tile tile = tile_pool.PopTile (row, col);
		if (tile) {
			StakeClaim (tile);
			tile.DoneProcessing ();
			return true;
		}
		return false;
	}

	protected bool ClaimSelectedActive ()
	{
		Tile tile = tile_pool.PopSelectedActive ();
		if (tile) {
			StakeClaim (tile);
			tile.DoneProcessing ();
//			tile_pool.HighlightAdjacent (pending_claims);
			return true;
		}
		return false;
	}

	protected virtual void ReturnTileObject (Tile tile)
	{
//		tile.TileObject = null;
	}

	protected virtual void StoreComponent (Tile tile)
	{
	}

	protected void AbandonClaim (Tile tile)
	{
		ReturnTileObject (tile);
		tile_pool.PushTile (tile);
		pending_claims.Remove (tile);
	}

	protected void AbandonAllClaims ()
	{
		foreach (Tile tile in tile_list) {
			ReturnTileObject (tile);
			tile_pool.PushTile (tile);
		}
		pending_claims.Clear ();
	}

	protected void FinalizeClaims ()
	{
		foreach (Tile tile in pending_claims) {
			tile_list.Add (tile);
			StoreComponent (tile);
			tile.transform.SetParent (transform);
		}
		pending_claims.Clear ();
		UnhighlightAll ();
		tile_pool.UnhighlightAll ();
	}

	protected void UnhighlightAll ()
	{
		foreach (Tile tile in tile_list) {
			tile.highlight = false;
		}
	}

	protected void consoleHighlight (string[] command)
	{
//		if (command [0].Equals ("all", System.StringComparison.Ordinal)) {
		foreach (Tile tile in tile_list) {
			tile.highlight = !tile.highlight;
		}
//		}
	}
}
