using UnityEngine;
using System.Collections;

public class UI_ResourceCounter : MonoBehaviour {

//	private Supply playerSupply;
	public TextMesh display;
	public TextMesh modifier;
	public TextMesh modifier_amount;
	public Resource.ResourceType resource;
	public Transform token_location;
	public Color positive_color;
	public Color negative_color;

	// Use this for initialization
	void Start () {
//		playerSupply = GameObject.Find("PlayerSupply").GetComponent<Supply>();
//		display = transform.FindChild("Display").GetComponent<TextMesh>();
		GameObject token = ResourceList.GetPrefab(resource);
		if(token){
			GameObject display_token = Instantiate(token) as GameObject;
//			display_token.layer = 5; // set UI layer
			display_token.rigidbody.useGravity = false;
			display_token.transform.SetParent(token_location);
			display_token.SetLayerRecursively(5); // set UI layer
		}
	}
	
	// Update is called once per frame
	void Update () {
		display.text = PlayerHandler.ActivePlayerResourceCount(resource).ToString();
		int m = Interface.getModifier(resource);
		if(m > 0){
			modifier.text = "+";
			modifier.color = positive_color;
			modifier_amount.text = m.ToString();
			modifier_amount.color = positive_color;
		}else if(m < 0){
			modifier.text = "-";
			modifier.color = negative_color;
			modifier_amount.text = (-m).ToString();
			modifier_amount.color = negative_color;
		}else{
			modifier.text = "";
			modifier_amount.text = "";
		}
	}
}
