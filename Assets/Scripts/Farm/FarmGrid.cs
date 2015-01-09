using UnityEngine;
using System.Collections;

public class FarmGrid : MonoBehaviour {

	private Tile[,] grid;

	// Use this for initialization
	void Awake () {
		grid = new Tile[3,5];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 gridPoint(int row, int col){
		Vector3 pos = transform.position;
		Vector3 diff = Vector3.zero;
		diff.x = col*transform.lossyScale.x;
		diff.z = row*transform.lossyScale.z;
		return pos + transform.rotation*diff;
	}

	public void AssignToGrid(GameObject item, int row, int col){
		if(checkBounds(row,col)){
			item.transform.position = gridPoint(row,col);
			Tile tile = item.GetComponent<Tile>();
			if(tile){
				grid[row,col] = tile;
			}
		}
	}

	private bool checkBounds(int row, int col){
		return row <= 2 && row >= 0 && col <= 4 && col >= 0;
	}
}
