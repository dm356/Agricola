using UnityEngine;
using System.Collections;

public class PlayerInput : Singleton<PlayerInput> {
//	public Supply playerSupply;
	public Transform main_viewpoint;
	public Transform farm_viewpoint;
	private SnapToTarget camera_control;
	public LayerMask clickables;
	public LayerMask storage;
	public LayerMask UI_clickables;
	public Camera UI_camera;
	public Transform test_sphere;
	public Transform test_sphere2;

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
					handler.SetupAction();
				}
			}
			Debug.Log(UI_camera.ScreenPointToRay(Input.mousePosition).origin);
			test_sphere.position = UI_camera.ScreenPointToRay(Input.mousePosition).origin;
			test_sphere2.position = UI_camera.ScreenPointToRay(Input.mousePosition).origin + UI_camera.ScreenPointToRay(Input.mousePosition).direction;
			if(Physics.Raycast(UI_camera.ScreenPointToRay(Input.mousePosition),out hit,1000f,UI_clickables)){
				UI_Action handler = hit.collider.gameObject.GetComponent<UI_Action>();
				if(handler){
					handler.Execute();
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
