using UnityEngine;
using System.Collections;

public class PlayerInput : Singleton<PlayerInput> {
//	public Supply playerSupply;
	public Transform main_viewpoint;
	public Transform farm_viewpoint;
	private SnapToTarget camera_control;

	// Use this for initialization
	void Start () {
		camera_control = Camera.main.GetComponent<SnapToTarget>();
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
		if(Input.GetAxis("Vertical") > 0f){
			camera_control.target = main_viewpoint;
		}else if(Input.GetAxis("Vertical") < -0f){
			camera_control.target = farm_viewpoint;
		}
	}
}
