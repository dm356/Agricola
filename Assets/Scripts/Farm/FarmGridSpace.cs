using UnityEngine;
using System.Collections;

public class FarmGridSpace : MonoBehaviour {
//	public GameObject object_prefab;
	private GameObject visual_instance;
	public Transform visual_location;
	[HideInInspector]
	public int x;
	[HideInInspector]
	public int y;
	private bool _clicked = false;
	private bool _selected = false;
//	private bool _active = false;
	public Tile.TileType tile_type = Tile.TileType.None;
	public MeshRenderer renderer;

	void Update(){
		if(Clicked){
			Selected = !_selected;
		}
	}

	public bool Selected{
		get{
			return _selected;
		}
		set{
			if(visual_instance){
				visual_instance.SetActive(value);
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

	public void Activate(GameObject prefab){
		visual_instance = Instantiate(prefab,visual_location.position,visual_location.rotation) as GameObject;
		visual_instance.transform.parent = transform;
		visual_instance.SetActive(false);
		_clicked = false;
		_selected = false;
		gameObject.SetActive(true);
	}

	public void Deactivate(){
		Destroy(visual_instance);
		visual_instance = null;
		_clicked = false;
		_selected = false;
		gameObject.SetActive(false);
	}

//	public GameObject SpawnVisual(GameObject prefab){
//		visual_instance = Instantiate(prefab,visual_location.position,visual_location.rotation) as GameObject;
//		visual_instance.transform.parent = transform;
//		visual_instance.SetActive(false);
//		return visual_instance;
//	}
}
