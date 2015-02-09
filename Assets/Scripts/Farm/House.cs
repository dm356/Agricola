using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : AbstractStorage {
	public enum HouseType {Wood,Clay,Stone}
	public GameObject player_token;

	private List<Room> rooms;
	public FarmGrid grid;
	public GameObject room_prefab;
//	public GameObject selectabelPrefab;
	private HouseType _type;

	public GameObject selectable_prefab;
	private List<Selectable> selectables;
	private GameObject temp_housing;

	public HouseType type{
		get{
			return _type;
		}
		set{
			_type = value;
			foreach(Room room in rooms){
				room.type = value;
			}
		}
	}

	void Start(){
		selectables = new List<Selectable>();
		rooms = new List<Room>();
		SetupInitialHouse();
//		grid.setAllSelectable();
	}

	void SetupInitialHouse(){
		spawnRoom(0,0);
		spawnRoom(1,0);
		addFamily(2);
	}

	void spawnRoom(int row, int col){
		GameObject room = Instantiate(room_prefab) as GameObject;
		grid.AssignToGrid(room,row,col);
		room.transform.parent = transform;
		Room rclass = room.GetComponent<Room>();
		rclass.x = row;
		rclass.y = col;
		rooms.Add(rclass);
		rclass.type = type;
	}

	public void BuildRooms(){
		temp_housing = new GameObject();
		temp_housing.transform.parent = transform.parent;
		GameObject s_obj;
		Selectable s_comp;
		for(int i=0;i<3;i++){
			for(int j=0;j<5;j++){
				if(grid.CheckType(i,j) == Tile.TileType.None){
					s_obj = Instantiate(selectable_prefab,grid.gridPoint(i,j),Quaternion.identity) as GameObject;
					s_obj.transform.parent = temp_housing.transform;
					s_comp = s_obj.GetComponent<Selectable>();
					selectables.Add(s_comp);
					s_comp.x = i;
					s_comp.y = j;
				}
			}
		}
	}

	public bool CheckAdjacency(){
		int min_dist, dist;
		foreach(Selectable selectable in selectables){
			if(selectable.Selected){
				min_dist = 10;
				foreach(Selectable other in selectables){
					if(selectable == other || !other.Selected){
						continue;
					}
					dist = Mathf.Abs(other.x-selectable.x) + Mathf.Abs(other.y-selectable.y);
					if(dist < min_dist){
						min_dist = dist;
					}
				}
				foreach(Room other in rooms){
					dist = Mathf.Abs(other.x-selectable.x) + Mathf.Abs(other.y-selectable.y);
					if(dist < min_dist){
						min_dist = dist;
					}
				}
				if(min_dist > 1){
					return false;
				}
			}
		}
		return true;
	}

	public void SetRooms(){
		foreach(Selectable selectable in selectables){
			if(selectable.Selected){
				spawnRoom(selectable.x,selectable.y);
			}
		}
		ClearSelectables();
	}

	public void ClearSelectables(){
		selectables.Clear();
		Destroy(temp_housing);
		temp_housing = null;
	}

	public void addFamily(int count){
		for(int i=0;i<count;i++){
			AddStock(Instantiate(player_token) as GameObject);
		}
	}

	public int BuildCount{
		get{
			int count = 0;
			foreach(Selectable s in selectables){
				if(s.Selected)
					count++;
			}
			return count;
		}
	}

	public override int Count{
		get{
			int n = 0;
			foreach(Room room in rooms){
				n += room.Count;
			}
			return n;
		}
	}

	public override void AddStock(GameObject token){
		Room min_room = null;
		int min_count = 1000000;
		foreach(Room room in rooms){
			if(room.Count < min_count){
				min_count = room.Count;
				min_room = room;
			}
		}
		min_room.AddStock(token);
	}
	
	public override GameObject PullToken(){
		Room max_room = null;
		int max_count = 0;
		foreach(Room room in rooms){
			if(room.Count > max_count){
				max_count = room.Count;
				max_room = room;
			}
		}
		
		if(max_room){
			return max_room.PullToken();
		}else{
			Debug.Log("TokenStack.PullToken ERROR: No tokens left");
			return null;
		}
	}
}