using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmGrid : MonoBehaviour {

//	private Tile[,] grid;
	private FarmGridSpace[,] grid;
//	private List<GameObject> selectables;
	public GameObject selectable_prefab;
//	private bool _active = false;

	public void Activate(GameObject visual_prefab, Tile.TileType type_flag, FarmGridSpace.Location location){
//		_active = true;
		foreach(FarmGridSpace space in grid){
			if((space.tile_type & type_flag) == space.tile_type){
				space.Activate(visual_prefab, location);
			}
		}
	}

	public void Deactivate(){
//		_active = false;
		foreach(FarmGridSpace space in grid){
			space.Deactivate();
		}
	}

	// Use this for initialization
	void Awake () {
		grid = new FarmGridSpace[3,5];
		GameObject s;
		for(int i=0;i<3;i++){
			for(int j=0;j<5;j++){
				s = Instantiate(selectable_prefab,gridPoint(i,j),Quaternion.identity) as GameObject;
				s.transform.parent = transform;
				grid[i,j] = s.GetComponent<FarmGridSpace>();
				grid[i,j].x = i;
				grid[i,j].y = j;
			}
		}

		Deactivate();
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
				grid[row,col].tile_type = tile.type;
			}
		}
	}

	private bool checkBounds(int row, int col){
		return row <= 2 && row >= 0 && col <= 4 && col >= 0;
	}

	public void buildRoomsFromSelected(House house){
		for(int i=0;i<3;i++){
			for(int j=0;j<5;j++){
				if(grid[i,j].Selected){
					house.SpawnRoom(i,j);
				}
			}
		}
	}
	
	public void buildFieldsFromSelected(FieldHandler handler){
		for(int i=0;i<3;i++){
			for(int j=0;j<5;j++){
				if(grid[i,j].Selected){
					handler.SpawnField(i,j);
				}
			}
		}
	}

	public int NumberSelected(){
		int count = 0;
		foreach(FarmGridSpace space in grid){
			if(space.Selected){
				count++;
			}
		}
		return count;
	}

	public bool CheckConnectivity(Tile.TileType tile_flag, Tile.TileType open_flag){
		List<FarmGridSpace> open_list = new List<FarmGridSpace>(), closed_list = new List<FarmGridSpace>();
		// Check tiles that are already set
		int num_set = 0;
		foreach(FarmGridSpace space in grid){
			if(Tile.CheckFlag(space.tile_type,tile_flag)){
				num_set++;
				foreach(FarmGridSpace neighbor in neighbors(space,open_flag)){
					if(neighbor.Selected && !open_list.Contains(neighbor)){
						open_list.Add(neighbor);
					}
				}
				closed_list.Add(space);
			}
		}

		// if nothing set, can place anywhere.  Start from any selected tile
		if(num_set == 0){
			foreach(FarmGridSpace space in grid){
				if(Tile.CheckFlag(space.tile_type,open_flag) && space.Selected){
					foreach(FarmGridSpace neighbor in neighbors(space,open_flag)){
						if(neighbor.Selected && !open_list.Contains(neighbor)){
							open_list.Add(neighbor);
						}
					}
					closed_list.Add(space);
					break;
				}
			}
		}

		FarmGridSpace current;
		while(open_list.Count > 0){
			current = open_list[0];
			open_list.RemoveAt(0);
			foreach(FarmGridSpace neighbor in neighbors(current,open_flag)){
				if(neighbor.Selected && !open_list.Contains(neighbor) && !closed_list.Contains(neighbor)){
					open_list.Add(neighbor);
				}
			}
			closed_list.Add(current);
		}

		return closed_list.Count - num_set == NumberSelected();
	}

	List<FarmGridSpace> neighbors(FarmGridSpace center, Tile.TileType flag = Tile.TileType.ALL){
		List<FarmGridSpace> list = new List<FarmGridSpace>();
		int i=center.x+1,j=center.y;
		if(checkBounds(i,j) && Tile.CheckFlag(grid[i,j].tile_type,flag)){
			list.Add(grid[i,j]);
		}
		i = center.x-1;
		j = center.y;
		if(checkBounds(i,j) && Tile.CheckFlag(grid[i,j].tile_type,flag)){
			list.Add(grid[i,j]);
		}
		i = center.x;
		j = center.y+1;
		if(checkBounds(i,j) && Tile.CheckFlag(grid[i,j].tile_type,flag)){
			list.Add(grid[i,j]);
		}
		i = center.x;
		j = center.y-1;
		if(checkBounds(i,j) && Tile.CheckFlag(grid[i,j].tile_type,flag)){
			list.Add(grid[i,j]);
		}
		return list;
	}

	public Tile.TileType CheckType(int row, int col){
		if(checkBounds(row,col)){
			return grid[row,col].tile_type;
		}else{
			return Tile.TileType.None;
		}
	}
}
