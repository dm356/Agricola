using UnityEngine;
using System.Collections;

public class PlayerInput : Singleton<PlayerInput> {
//	public Supply playerSupply;
	public Transform main_viewpoint;
	public Transform farm_viewpoint;
	private SnapToTarget camera_control;
	public LayerMask clickables;
	public LayerMask storage;

	private bool debug_mode = true;

	// Use this for initialization
	void Start () {
		camera_control = Camera.main.GetComponent<SnapToTarget>();
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
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,clickables)){
				ActionSpace handler = hit.collider.gameObject.GetComponent<ActionSpace>();
				if(handler){
					handler.ExecuteAction();
				}
			}
		}
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,storage)){
				StockResource handler = hit.collider.gameObject.GetComponent<StockResource>();
				if(handler){
					handler.Restock();
				}
			}
		}

		if(Input.GetKeyDown("n")){
			TurnManager.NextRound();
		}
	}
}
