using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionManager : Singleton<ActionManager> {

	private List<Action> pending_actions;

	// Use this for initialization
	void Awake () {
		pending_actions = new List<Action>();
	}
	
	public int ResourceModifier(Resource.ResourceType resource){
		int modifier = 0;
		foreach(Action act in pending_actions){
			modifier += act.ResourceModifier(resource);
		}
		return modifier;
	}

	public void AddActionToQueue(Action action){
		pending_actions.Add(action);
	}

	public void Execute(){
		foreach(Action act in pending_actions){
			act.Execute();
		}
		pending_actions.Clear();
	}
}
