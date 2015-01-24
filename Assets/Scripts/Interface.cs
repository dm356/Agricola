using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class Interface : Singleton<Interface> {
	public GameObject confirm_prefab;
	public Transform confirm_location;
	private Dictionary<Resource.ResourceType,int> modifier_amounts;

	public void Awake(){
		modifier_amounts = new Dictionary<Resource.ResourceType, int>();
		resetModifiers();
	}

	static public GameObject awaitConfirmation(){
		GameObject button = Instantiate(Instance.confirm_prefab,Instance.confirm_location.position,Instance.confirm_location.rotation) as GameObject;
		button.transform.parent = Instance.transform;
		return button;
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