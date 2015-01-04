using UnityEngine;
using System.Collections;

public class PlayerInput : Singleton<PlayerInput> {
//	public Supply playerSupply;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,1 << 9)){
				DropPlayer handler = hit.collider.gameObject.GetComponent<DropPlayer>();
				if(handler){
					handler.Activate();
				}
			}
		}
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,1 << 9)){
				StockResource handler = hit.collider.gameObject.GetComponent<StockResource>();
				if(handler){
					handler.Restock();
				}
			}
		}
	}
}
