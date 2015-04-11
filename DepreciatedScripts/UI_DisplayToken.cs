using UnityEngine;
using System.Collections;

public class UI_DisplayToken : MonoBehaviour {
	public GameObject token;

	// Use this for initialization
	void Awake () {
		if(token){
			GameObject display_token = Instantiate(token) as GameObject;
			display_token.layer = 5; // set UI layer
			display_token.rigidbody.useGravity = false;
			display_token.transform.SetParent(transform);
		}
	}
}
