using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	public GameObject highlight_object;

	private int x_ind;
	private int y_ind;
	private GameObject tile_object;
	private bool clicked = false;

	void LateUpdate ()
	{
		clicked = false;
	}

	public GameObject TileObject {
		set {
			tile_object = value;
			if (tile_object) {
				tile_object.transform.SetParent (transform, false);
				tile_object.transform.position = transform.position;
//				tile_object.transform.rotation = transform.rotation;
			}


		}
		get {
			return this.tile_object;
		}
	}

	public bool highlight {
		set {
			highlight_object.SetActive (value);
		}
		get {
			return highlight_object.activeSelf;
		}
	}

	public bool selected {
		get {
			return clicked;
		}
	}

	public void DoneProcessing ()
	{
//		highlight = false;
		clicked = false;
	}

	public bool matches (int row, int col)
	{
		return x_ind == row && y_ind == col;
	}

	public bool adjacent (Tile other)
	{
		int dx = x_ind - other.x_ind;
		int dy = y_ind - other.y_ind;
		return dx * dx + dy * dy <= 1;
	}

	public int X {
		set {
			x_ind = value;
		}
//		get {
//			return x_ind;
//		}
	}

	public int Y {
		set {
			y_ind = value;
		}
//		get {
//			return y_ind;
//		}
	}

	void OnMouseDown ()
	{
//		Debug.Log ("Tile clicked: (" + x_ind + "," + y_ind + ")");
		if (highlight)
			clicked = true;
	}
}
