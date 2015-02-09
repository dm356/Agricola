using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
//	public GameObject object_prefab;
	private GameObject visual_instance;
	public Transform visual_location;
//	public Material unselected;
//	public Material selected;
//	public MeshRenderer plane;
//	private bool on = false;
	[HideInInspector]
	public int x;
	[HideInInspector]
	public int y;
	[HideInInspector]
	private bool _clicked = false;
	private bool _selected = false;

	public bool Selected{
		get{
			return _selected;
		}
		set{
			if(!value & visual_instance){
				Destroy(visual_instance);
				visual_instance = null;
			}
			_selected = value;
		}
	}

	public bool Clicked{
		get{
			bool val = _clicked;
			_clicked = false;
			return val;
		}
		set{
			_clicked = value;
		}
	}

	void OnMouseDown(){
		Clicked = true;
//		if(on){
//			plane.material = unselected;
//			Destroy(object_instance);
//			object_instance = null;
//			Selected = false;
//		}else{
//			plane.material = selected;
//			object_instance = Instantiate(object_prefab,object_location.position,object_location.rotation) as GameObject;
//			object_instance.transform.parent = transform;
//			Selected = true;
//		}
	}

	public GameObject SpawnVisual(GameObject prefab){
		visual_instance = Instantiate(prefab,visual_location.position,visual_location.rotation) as GameObject;
		visual_instance.transform.parent = transform;
		visual_instance.collider.enabled = false;
		return visual_instance;
	}
}
