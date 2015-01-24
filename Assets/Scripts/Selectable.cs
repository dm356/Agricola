using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
	public Material unselected;
	public Material selected;
	public MeshRenderer plane;
	private bool on = false;

	void OnMouseDown(){
		if(on){
			plane.material = unselected;
			on = false;
		}else{
			plane.material = selected;
			on = true;
		}
	}
}
