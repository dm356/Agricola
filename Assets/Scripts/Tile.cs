using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	[System.Flags]
	public enum TileType{
		None = 0x01,
		Room = 0x02,
		Field = 0x04,
		Pasture = 0x08,
		ALL = 0xFF
	}
	public TileType type = TileType.None;

	public static bool CheckFlag(TileType type, TileType flag){
		return (type & flag) == type;
	}
}
