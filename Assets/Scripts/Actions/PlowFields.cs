using UnityEngine;
using System.Collections;

public class PlowFields : Action
{

	public int limit = 15;

	public override bool Valid {
		get {
//			FarmGrid grid = PlayerHandler.CurrentPlayerFarm.fields.grid;
//			if (grid.CheckConnectivity (Tile.TileType.Field, Tile.TileType.None) && grid.NumberSelected () <= limit) {
//				return base.Valid;
//			}
			return false;
		}
	}

	public override void Setup ()
	{
//		active = true;
		PlayerInput.ShowCurrentPlayerFarm ();
//		PlayerHandler.CurrentPlayerFarm.fields.PlowFields ();
		base.Setup ();
	}

	public override void Execute ()
	{
//		PlayerHandler.CurrentPlayerFarm.fields.SetFields ();
	}

	public override void Cancel ()
	{
//		PlayerHandler.CurrentPlayerFarm.fields.ClearSelectables ();
		base.Cancel ();
	}
}
