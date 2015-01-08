using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HouseHandler : MonoBehaviour {
	private List<TokenStorage> rooms;

	void Start(){
		rooms = new List<TokenStorage>();
		TokenStorage storage;
		foreach(Transform child in transform){
			storage = child.GetComponent<TokenStorage>();
			if(storage){
				rooms.Add(storage);
			}
		}
	}
}