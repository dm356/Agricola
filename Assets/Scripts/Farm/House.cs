using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : AbstractStorage {
	public enum HouseType {Wood,Clay,Stone}
	public GameObject player_token;

	private List<Room> rooms;
	public FarmGrid grid;
	public GameObject roomPrefab;
	public GameObject selectabelPrefab;
	private HouseType _type;

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
		GameObject room = Instantiate(roomPrefab) as GameObject;
		grid.AssignToGrid(room,row,col);
		room.transform.parent = transform;
		Room rclass = room.GetComponent<Room>();
		rooms.Add(rclass);
		rclass.type = type;
	}

	public void addFamily(int count){
		for(int i=0;i<count;i++){
			AddStock(Instantiate(player_token) as GameObject);
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