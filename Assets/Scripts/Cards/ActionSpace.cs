using UnityEngine;
using System.Collections;

public class ActionSpace : MonoBehaviour {

	public AbstractStorage player_stack;
	public Action activated_action;

	// Use this for initialization
	void Start () {
//		foreach(Transform child in transform){
//			storage = child.GetComponent<AbstractStorage>();
//			if(storage)
//				break;
//		}
//		action = GetComponent<Action>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void ExecuteAction(){
		GameObject token = Supply.GetPlayerToken();
		player_stack.AddStock(token);

		if(activated_action){
			activated_action.Execute();
		}
	}
}
