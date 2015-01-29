using UnityEngine;
using System.Collections;

public class PlayerInput : Singleton<PlayerInput> {
//	public Supply playerSupply;
	public Transform main_viewpoint;
	public Transform farm_viewpoint;
	private SnapToTarget camera_control;
	public LayerMask action_spaces;
	public LayerMask clickables;
	public LayerMask storage;
	public LayerMask UI_clickables;
	public Camera UI_camera;
	public Transform test_sphere;
	public Transform test_sphere2;
	public int player_id = 0;

	public bool debug_mode = true;

	[System.Flags]
	public enum InputState{
		NullState = 0x0,
		PlaceToken = 0x1,
		ViewChange = 0x2,
		UIAction = 0x4
	}

	private InputState input_state = InputState.ViewChange | InputState.UIAction;

	public static int Id{
		get{
			return Instance.player_id;
		}
	}

	// Use this for initialization
	void Start () {
		camera_control = Camera.main.GetComponent<SnapToTarget>();
	}
	
	// Update is called once per frame
	void Update () {
		if(debug_mode)
			DebugActions();

		if(CheckFlags(InputState.PlaceToken)){
			PlaceTokenActions();
		}
		if(CheckFlags(InputState.ViewChange)){
			if(Input.GetAxis("Vertical") > 0f){
				camera_control.target = main_viewpoint;
			}else if(Input.GetAxis("Vertical") < -0f){
				camera_control.target = farm_viewpoint;
			}
		}
		if(CheckFlags(InputState.UIAction)){
			UIActions();
		}
	}

	static public void SetFlag(InputState flag, bool on){
		if(on){
			Instance.input_state |= flag;
		}else{
			Instance.input_state &= ~flag;
		}
	}

	void PlaceTokenActions(){
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,action_spaces)){
				ActionSpace handler = hit.collider.gameObject.GetComponent<ActionSpace>();
				if(handler && !handler.Occupied){
					handler.SetupAction();
					SetFlag(InputState.PlaceToken, false);
				}
			}
		}
	}

	void UIActions(){
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			if(Physics.Raycast(UI_camera.ScreenPointToRay(Input.mousePosition),out hit,1000f,UI_clickables)){
				UI_Action handler = hit.collider.gameObject.GetComponent<UI_Action>();
				if(handler){
					handler.Execute();
				}
			}
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

	bool CheckFlags(InputState flag){
		return (input_state & flag) == flag;
	}
}
