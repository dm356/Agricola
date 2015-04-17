using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoiceAction : Action {

//	public GameObject window_prefab;
	private GameObject window_instance = null;

	public List<Action> actions;

	private int selected_action = 0;

	public override void Execute ()
	{
		actions[selected_action].Execute();
	}

//	public override void Setup ()
//	{
//		window_instance = Instantiate(window_prefab,Interface.WindowLocation.position,Interface.WindowLocation.rotation) as GameObject;
//		window_instance.transform.parent = Interface.Instance.transform;
//		UI_SelectionWindow window = window_instance.GetComponent<UI_SelectionWindow>();
//		window.BuildSelectables(actions);
//	}

	public override void RoundSetup ()
	{
		foreach(Action action in actions){
			action.RoundSetup();
		}
	}

	public override void Cancel ()
	{
		actions[selected_action].Cancel();
	}
	
	// Update is called once per frame
	void Update () {
		if(window_instance){
			UI_SelectionWindow window = window_instance.GetComponent<UI_SelectionWindow>();
			if(window){
				if(window.Confirmed){
					actions[window.SelectedAction].Setup();
					selected_action = window.SelectedAction;
					Destroy(window_instance);
					window_instance = null;
					base.Setup();
				}else if(window.Canceled){
					Destroy(window_instance);
					window_instance = null;
					Interface.Cancel();
				}
			}
		}
	}
}
