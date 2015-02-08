using UnityEngine;
using System.Collections;

public class UI_Button : MonoBehaviour {
	private bool _clicked = false;
	public TextMesh text_mesh;

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

	public void SetText(string text){
		text_mesh.text = text;
	}
}
