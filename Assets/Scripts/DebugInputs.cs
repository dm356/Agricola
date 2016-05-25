using UnityEngine;
using System.Collections;

public class DebugInputs : MonoBehaviour {
	public bool active;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.BackQuote)){
			active = !active;
		}
		if(active){
//			if(Input.GetMouseButtonDown(0)){
//				RaycastHit hit;
//				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,clickables)){
//					ActionSpace handler = hit.collider.gameObject.GetComponent<ActionSpace>();
//					if(handler){
//						handler.SetupAction();
//					}
//				}
//			}
//			if(Input.GetMouseButtonDown(1)){
//				RaycastHit hit;
//				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,1000f,storage)){
//					StockResource handler = hit.collider.gameObject.GetComponent<StockResource>();
//					if(handler){
//						handler.Restock();
//					}
//				}
//			}

			if(Input.GetKeyDown("n")){
				TurnManager.NextRound();
			}
		}
	}
}
