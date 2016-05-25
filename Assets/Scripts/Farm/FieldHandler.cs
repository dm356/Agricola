using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldHandler : TileHandler
{
	enum Mode
	{
		IDLE,
		CLAIM_FIELD,
		SOW}
	;

	private List<Field> fields;

	private Mode mode;

	void Start ()
	{
//		selectables = new List<Selectable>();
		fields = new List<Field> ();
		mode = Mode.IDLE;
		Console.addConsoleFunction ("field", consoleAction);
	}

	void Update ()
	{
		if (mode == Mode.CLAIM_FIELD) {
//			Debug.Log ("Claim");
			UpdateSelectable ();
		}
	}

	protected override void ReturnTileObject (Tile tile)
	{
		PoolManager.ReturnTile (TileMarkerType.FIELD, tile.TileObject);
		base.ReturnTileObject (tile);
	}

	protected override void StoreComponent (Tile tile)
	{
		fields.Add (tile.TileObject.GetComponent<Field> ());
		base.StoreComponent (tile);
	}

	public override void StakeClaim (Tile tile)
	{
		base.StakeClaim (tile);
		GameObject field = PoolManager.GetTile (TileMarkerType.FIELD);
		tile.TileObject = field;
	}

	public void BuildFields ()
	{
//		grid.Activate (room_prefab, Tile.TileType.None, FarmGridSpace.Location.Tile);
//		PlayerInput.SetFlag (PlayerInput.InputState.FarmAction, true);
		mode = Mode.CLAIM_FIELD;
		InitializeSelectable ();
	}

	public void AcceptFields ()
	{
		mode = Mode.IDLE;
		FinalizeClaims ();
	}

	void consoleAction (string[] command)
	{
		if (command.Length < 1) {
			Debug.Log ("Insufficient command length.");
		}

		string[] sub = new string[command.Length - 1];
		for (int i = 1; i < command.Length; i++) {
			sub [i - 1] = command [i];
		}
		if (command [0] == "highlight") {
			consoleHighlight (sub);
		} else if (command [0] == "build") {
			BuildFields ();
		} else if (command [0] == "accept") {
			AcceptFields ();
		}

	}
}
