using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class Interface : Singleton<Interface> {
	public Slider confirm_slider;
	public Slider cancel_slider;
	private Dictionary<Resource.ResourceType,int> modifier_amounts;
	public UI_Button confirm;
	public UI_Button cancel;
	public ActionSpace waitingAction;
	public Transform window_location;

	static public void Confirm(){
//		Instance.waitingAction.ExecuteAction();
		ShowButtons(false);
		resetModifiers();
		TurnManager.CyclePlayers();
		Instance.waitingAction = null;
	}

	static public void Cancel(){
		Instance.waitingAction.CancelAction();
		ShowButtons(false);
		resetModifiers();
		// Allow player to place token again
		PlayerInput.SetFlag(PlayerInput.InputState.PlaceToken, true);
		Instance.waitingAction = null;
	}

	static public Transform WindowLocation{
		get{
			return Instance.window_location;
		}
	}

	static public void ShowButtons(bool on){
		Instance.confirm_slider.hidden = !on;
		Instance.cancel_slider.hidden = !on;
	}

	void Awake(){
		modifier_amounts = new Dictionary<Resource.ResourceType, int>();
		resetModifiers();
	}

	void Update(){
		if(waitingAction){
			confirm.Active = waitingAction.Valid;
		}
		if(confirm.Clicked){
			Confirm();
		}else if(cancel.Clicked){
			Cancel();
		}
	}

	static public void awaitConfirmation(ActionSpace action){
		Instance.waitingAction = action;
//		ShowButtons(true);
	}

	static public void setModifier(Resource.ResourceType resource, int amount){
		if(Instance.modifier_amounts.ContainsKey(resource)){
			Instance.modifier_amounts[resource] = amount;
		}
	}

	static public void resetModifiers(){
		foreach(Resource.ResourceType resource in Enum.GetValues(typeof(Resource.ResourceType))){
			Instance.modifier_amounts[resource] = 0;
		}
	}

	static public int getModifier(Resource.ResourceType resource){
		if(Instance.modifier_amounts.ContainsKey(resource)){
			return Instance.modifier_amounts[resource];
		}
		return 0;
	}
}