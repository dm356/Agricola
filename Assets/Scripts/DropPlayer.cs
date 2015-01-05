using UnityEngine;
using System.Collections;

public class DropPlayer : MonoBehaviour {

	public Transform drop_location;
	private int player_count = 0;

	// Use this for initialization
	void Start () {
//		drop_location = transform.FindChild("PlayerStack");;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate(){
		GameObject token = Supply.GetPlayerToken();
		float height = token.transform.lossyScale.y*(0.5f + 2f*((float) player_count)) + 0.5f;
		token.transform.position = drop_location.position + drop_location.up*height;
		token.transform.rotation = drop_location.rotation;

		player_count += 1;

		Action action = GetComponent<Action>();
		if(action){
			action.Execute();
		}
	}
}
