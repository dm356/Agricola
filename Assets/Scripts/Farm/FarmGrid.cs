using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmGrid : MonoBehaviour {

	private Tile[,] grid;
	private List<GameObject> selectables;
	public GameObject selectablePrefab;

	// Use this for initialization
	void Awake () {
		grid = new Tile[3,5];
		for(int i=0;i<3;i++){
			for(int j=0;j<5;j++){
				grid[i,j] = GetComponent<Tile>();
			}
		}
		selectables = new List<GameObject>();
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

	public void setSelectable(int row, int col){
		if(checkBounds(row,col)){
			GameObject s = Instantiate(selectablePrefab,gridPoint(row,col),Quaternion.identity) as GameObject;
			selectables.Add(s);
		}
	}

	public void setAllSelectable(){
		for(int i=0;i<3;i++){
			for(int j=0;j<5;j++){
				setSelectable(i,j);
			}
		}
	}

	public Tile.TileType CheckType(int row, int col){
		if(checkBounds(row,col)){
			return grid[row,col].type;
		}else{
			return Tile.TileType.None;
		}
	}

//	public List<GameObject> Populate(GameObject prefab, Tile.TileType flag){
//		GameObject s;
//		List<GameObject> list = new List<GameObject>();
//		for(int i=0;i<3;i++){
//			for(int j=0;j<5;j++){
//				if((grid[i,j].type & flag) == grid[i,j].type){
//					s = Instantiate(prefab,gridPoint(i,j),Quaternion.identity) as GameObject;
//					list.Add(s);
//				}
//			}
//		}
//		return list;
//	}
	
	public void destroySelectables(){
		foreach(GameObject s in selectables){
			Destroy(s);
		}
		selectables.Clear();
	}
}
