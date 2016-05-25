using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmGridSpace : MonoBehaviour
{
	private List<GameObject> prefabs_list;
	private int prefab_index = 0;
	private GameObject visual_instance;
	private Transform visual_location;
	public Transform resource_location;
	public Transform stable_location;
	[HideInInspector]
	public int x;
	[HideInInspector]
	public int y;
	private bool _clicked = false;
	private bool _selected = false;
	//	private bool _active = false;
	//	public Tile.TileType tile_type = Tile.TileType.None;
	public MeshRenderer m_renderer;

	[System.Flags]
	public enum Location
	{
		Tile,
		Resource,
		Stable
	}

	//	void Awake(){
	//		prefabs_list = new List<GameObject>();
	//	}

	void Update ()
	{
		if (Clicked) {
			if (++prefab_index > prefabs_list.Count) {
				prefab_index = 0;
			}

			SpawnPrefab ();
//			Selected = !_selected;
		}
	}

	public bool Selected {
		get {
			return _selected;
		}
		set {
//			if(visual_instance){
//				visual_instance.SetActive(value);
//			}

			_selected = value;
		}
	}

	public bool Clicked {
		get {
			bool val = _clicked;
			_clicked = false;
			return val;
		}
		set {
			_clicked = value;
		}
	}

	public void Activate (GameObject prefab, Location location)
	{
		if (location == Location.Resource) {
			visual_location = resource_location;
		} else if (location == Location.Stable) {
			visual_location = stable_location;
		} else if (location == Location.Tile) {
			visual_location = transform;
		}

		prefab_index = 0;
		prefabs_list = new List<GameObject> ();
		prefabs_list.Add (prefab);

//		visual_instance.SetActive(false);
		_clicked = false;
		_selected = false;

		gameObject.SetActive (true);
	}

	public void Activate (List<GameObject> prefabs, Location location)
	{
		if (location == Location.Resource) {
			visual_location = resource_location;
		} else if (location == Location.Stable) {
			visual_location = stable_location;
		} else if (location == Location.Tile) {
			visual_location = transform;
		}
		
		prefab_index = 0;
		prefabs_list = prefabs;
		
		//		visual_instance.SetActive(false);
		_clicked = false;
		_selected = false;
		
		gameObject.SetActive (true);
	}

	public void Deactivate ()
	{
		if (visual_instance) {
			Destroy (visual_instance);
			visual_instance = null;
		}
		_clicked = false;
		_selected = false;
		gameObject.SetActive (false);
	}

	public int Index ()
	{
		return prefab_index - 1;
	}

	void SpawnPrefab ()
	{
		if (visual_instance) {
			Destroy (visual_instance);
			visual_instance = null;
		}
		if (prefab_index > 0) {
			visual_instance = Instantiate (prefabs_list [prefab_index - 1], visual_location.position, visual_location.rotation) as GameObject;
			visual_instance.transform.parent = transform;
		}
	}
}
