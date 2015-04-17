using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_SelectionWindow : MonoBehaviour {
	public GameObject option_prefab;
	private List<UI_Button> buttons;
	private int selected = 0;
	public Transform highlight;

	public UI_Button confirm;
	public UI_Button cancel;

	public float height = 0.04f;
	public Transform selectables;

	public int SelectedAction{
		get{
			return selected;
		}
	}

	void Awake(){
		buttons = new List<UI_Button>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<buttons.Count;i++){
			if(buttons[i].Clicked){
				selected = i;
			}
		}
		highlight.position = buttons[selected].transform.position;
	}

	public void BuildSelectables(List<Action> actions){
		GameObject option;
		float l = height/((float) actions.Count);
		float y = selectables.position.y + height/2f - 0.5f*l;
		UI_Button button;
		foreach(Action action in actions){
			Vector3 p = selectables.position;
			p.y = y;
			option = Instantiate(option_prefab,p,selectables.rotation) as GameObject;
			button = option.GetComponent<UI_Button>();
//			button.SetText(action.name);
			button.SetText("");
			buttons.Add(button);
			option.transform.parent = selectables;
			y -= l;
		}
	}

	public bool Confirmed{
		get{
			return confirm.Clicked;
		}
	}

	public bool Canceled{
		get{
			return cancel.Clicked;
		}
	}
}
