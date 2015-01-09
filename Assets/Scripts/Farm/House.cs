using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {
	public enum HouseType {Wood,Clay,Stone}

	private List<Room> rooms;
	public FarmGrid grid;
	public GameObject roomPrefab;
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
	}

	void SetupInitialHouse(){
//		for(int i=0;i<3;i++){
//			for(int j=0;j<5;j++){
//				spawnRoom(i,j);
//			}
//		}
		spawnRoom(0,0);
		spawnRoom(1,0);
	}

	void spawnRoom(int row, int col){
		GameObject room = Instantiate(roomPrefab) as GameObject;
		grid.AssignToGrid(room,row,col);
		room.transform.parent = transform;
		Room rclass = room.GetComponent<Room>();
		rooms.Add(rclass);
		rclass.type = type;
	}
}