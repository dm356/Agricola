using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	[System.Flags]
	public enum TileType{
		None = 0x01,
		Room = 0x02,
		Field = 0x04,
		Pasture = 0x08
	}
	public TileType type = TileType.None;
}
