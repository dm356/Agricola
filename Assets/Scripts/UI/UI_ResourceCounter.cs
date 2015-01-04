using UnityEngine;
using System.Collections;

public class UI_ResourceCounter : MonoBehaviour {

//	private Supply playerSupply;
	private TextMesh display;
	public Resource.ResourceType resource;

	// Use this for initialization
	void Start () {
//		playerSupply = GameObject.Find("PlayerSupply").GetComponent<Supply>();
		display = transform.FindChild("Display").GetComponent<TextMesh>();
		GameObject token = ResourceList.GetPrefab(resource);
		if(token){
			GameObject display_token = Instantiate(token) as GameObject;
			display_token.layer = 5; // set UI layer
			display_token.rigidbody.useGravity = false;
			display_token.transform.SetParent(transform.FindChild("Token"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		display.text = Supply.CheckStock(resource).ToString();
	}
}
