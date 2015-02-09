using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
	public GameObject object_prefab;
	private GameObject object_instance;
	public Transform object_location;
//	public Material unselected;
//	public Material selected;
//	public MeshRenderer plane;
	private bool on = false;
	[HideInInspector]
	public int x;
	[HideInInspector]
	public int y;

	public bool Selected{
		get{
			return on;
		}
	}

	void OnMouseDown(){
		if(on){
//			plane.material = unselected;
			Destroy(object_instance);
			object_instance = null;
			on = false;
		}else{
//			plane.material = selected;
			object_instance = Instantiate(object_prefab,object_location.position,object_location.rotation) as GameObject;
			object_instance.transform.parent = transform;
			on = true;
		}
	}
}
