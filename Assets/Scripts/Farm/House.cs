using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : TileHandler
{
	enum Mode
	{
		IDLE,
		CLAIM_ROOM,
		CHOOSE_FAMILY}
	;

	//	public GameObject player_token;

	private List<Room> rooms;

	private ResourceType _type;

	private Mode mode;

	public ResourceType type {
		get {
			return _type;
		}
		set {
			_type = value;
			foreach (Room room in rooms) {
				room.type = value;
			}
		}
	}

	void Start ()
	{
//		selectables = new List<Selectable>();
		rooms = new List<Room> ();
		SetupInitialHouse ();
//		grid.setAllSelectable();
		mode = Mode.IDLE;
		Console.addConsoleFunction ("house", consoleAction);
	}

	void Update ()
	{
		if (mode == Mode.CLAIM_ROOM) {
//			Debug.Log ("Claim");
			UpdateSelectable ();
		}
	}

	void SetupInitialHouse ()
	{
		type = ResourceType.Wood;
		ClaimIndexed (0, 0);
		ClaimIndexed (1, 0);
		FinalizeClaims ();
//		addFamily (2);
	}

	protected override void ReturnTileObject (Tile tile)
	{
		PoolManager.ReturnTile (TileMarkerType.ROOM, tile.TileObject);
		base.ReturnTileObject (tile);
	}

	protected override void StoreComponent (Tile tile)
	{
		rooms.Add (tile.TileObject.GetComponent<Room> ());
		base.StoreComponent (tile);
	}

	public override void StakeClaim (Tile tile)
	{
		base.StakeClaim (tile);
		GameObject room = PoolManager.GetTile (TileMarkerType.ROOM);
		tile.TileObject = room;
		room.GetComponent<Room> ().type = type;
	}

	public void BuildRooms ()
	{
//		grid.Activate (room_prefab, Tile.TileType.None, FarmGridSpace.Location.Tile);
//		PlayerInput.SetFlag (PlayerInput.InputState.FarmAction, true);
		mode = Mode.CLAIM_ROOM;
		InitializeSelectable ();
	}

	public void AcceptRooms ()
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
			BuildRooms ();
		} else if (command [0] == "accept") {
			AcceptRooms ();
		} else if (command [0] == "type") {
			if (command.Length < 2) {
				Debug.Log ("House mode command: [wood|clay|stone]");
				return;
			}
			switch (command [1]) {
			case "wood":
				type = ResourceType.Wood;
				break;
			case "clay":
				type = ResourceType.Clay;
				break;
			case "stone":
				type = ResourceType.Stone;
				break;
			}
		}

	}
}