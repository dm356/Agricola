using UnityEngine;
using System.Collections;

public class UI_Button : MonoBehaviour {
	private bool _clicked = false;
	public TextMesh text_mesh;
	public MeshRenderer background_mesh;
	public Material active_material;
	public Material inactive_material;
	private bool _active = true;

	public bool Active{
		get{
			return _active;
		}
		set{
			if(value){
				background_mesh.material = active_material;
			}else{
				background_mesh.material = inactive_material;
			}
			_active = value;
		}
	}

//	void OnMouseDown(){
//		if(_active){
//			_clicked = true;
//		}
//	}

	public bool Clicked{
		get{
			bool val = _clicked;
			_clicked = false;
			return val;
		}
		set{
			if(_active){
				_clicked = value;
			}
		}
	}

	public void SetText(string text){
		text_mesh.text = text;
	}
}
