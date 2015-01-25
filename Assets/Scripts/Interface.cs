using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class Interface : Singleton<Interface> {
	public Slider confirm_slider;
	public Slider cancel_slider;
	private Dictionary<Resource.ResourceType,int> modifier_amounts;
	public bool confirmed;
	public bool cancelled;
	public ActionSpace waitingAction;

	static public void Confirm(){
		Instance.confirmed = true;
		Instance.waitingAction.ExecuteAction();
		Instance.showButtons(false);
		resetModifiers();
	}

	static public void Cancel(){
		Instance.cancelled = true;
		Instance.waitingAction.CancelAction();
		Instance.showButtons(false);
		resetModifiers();
	}

	void showButtons(bool on){
		Instance.confirm_slider.hidden = !on;
		Instance.cancel_slider.hidden = !on;
	}

	public void Awake(){
		modifier_amounts = new Dictionary<Resource.ResourceType, int>();
		resetModifiers();
	}

	static public void awaitConfirmation(ActionSpace action){
		Instance.waitingAction = action;
		Instance.showButtons(true);
		Instance.confirmed = false;
		Instance.cancelled = false;
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