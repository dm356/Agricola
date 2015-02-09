using UnityEngine;
using System.Collections;

public class BuildRoom : Action {

	public int limit = 15;

	public override bool Valid {
		get {
			if(PlayerHandler.CurrentPlayerHouse.CheckAdjacency() && PlayerHandler.CurrentPlayerHouse.BuildCount <= limit){
				return base.Valid;
			}
			return false;
		}
	}

	public override void Setup ()
	{
		PlayerInput.ShowCurrentPlayerFarm();
		PlayerHandler.CurrentPlayerHouse.BuildRooms();
		base.Setup ();
	}

	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerHouse.SetRooms();
	}

	public override void Cancel ()
	{
		PlayerHandler.CurrentPlayerHouse.ClearSelectables();
		base.Cancel();
	}
}
