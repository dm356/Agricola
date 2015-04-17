using UnityEngine;
using System.Collections;

public class PlowFields : Action {

	public int limit = 15;

	public override bool Valid {
		get {
			FarmGrid grid = PlayerHandler.CurrentPlayerFields.grid;
			if(grid.CheckConnectivity(Tile.TileType.Field,Tile.TileType.None) && grid.NumberSelected() <= limit){
				return base.Valid;
			}
			return false;
		}
	}

	public override void Setup ()
	{
		PlayerInput.ShowCurrentPlayerFarm();
		PlayerHandler.CurrentPlayerFields.PlowFields();
		base.Setup ();
	}

	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerFields.SetFields();
	}

	public override void Cancel ()
	{
		PlayerHandler.CurrentPlayerFields.ClearSelectables();
		base.Cancel();
	}
}
