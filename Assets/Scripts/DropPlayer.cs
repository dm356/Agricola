using UnityEngine;
using System.Collections;

public class DropPlayer : MonoBehaviour {

	private TokenStorage storage;
	private Action action;

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform){
			storage = child.GetComponent<TokenStorage>();
			if(storage)
				break;
		}
		action = GetComponent<Action>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate(){
		GameObject token = Supply.GetPlayerToken();
		storage.AddStock(token);

		if(action){
			action.Execute();
		}
	}
}
