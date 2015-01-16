using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public enum TileType{None, Room, Field, Pasture}
	public TileType type = TileType.None;
}
