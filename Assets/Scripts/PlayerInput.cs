using UnityEngine;
using System.Collections;

public class PlayerInput : Singleton<PlayerInput> {
//	public Supply playerSupply;
	public Transform main_viewpoint;
	public Transform farm_viewpoint;
	private SnapToTarget camera_control;
	private int action_layer;
	private int storage_layer;
	private bool debug_mode = true;

	// Use this for initialization
	void Start () {
		camera_control = Camera.main.GetComponent<SnapToTarget>();
		action_layer = LayerMask.NameToLayer("actions");
		storage_layer = LayerMask.NameToLayer("storage");
	}
	
	// Update is called once per frame
	void Update () {
		DebugActions();

		if(Input.GetAxis("Vertical") > 0f){
			camera_control.target = main_viewpoint;
		}else if(Input.GetAxis("Vertical") < -0f){
			camera_control.target = farm_viewpoint;
		}
	}

	void DebugActions(){
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,1 << action_layer)){
				ActionSpace handler = hit.collider.gameObject.GetComponent<ActionSpace>();
				if(handler){
					handler.ExecuteAction();
				}
			}
		}
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,1 << storage_layer)){
				StockResource handler = hit.collider.gameObject.GetComponent<StockResource>();
				if(handler){
					handler.Restock();
				}
			}
		}
		if(Input.GetMouseButtonDown(2)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,1 << action_layer)){
				RoundCard handler = hit.collider.gameObject.GetComponent<RoundCard>();
				if(handler){
					handler.Activate();
				}
			}
		}

		if(Input.GetKeyDown("n")){
			TurnManager.NextRound();
		}
	}
}
