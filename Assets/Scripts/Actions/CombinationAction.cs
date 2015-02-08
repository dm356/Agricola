using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombinationAction : Action {
	public List<Action> actions;

	public override void Execute ()
	{
		foreach(Action action in actions){
			action.Execute();
		}
	}

	public override void Setup ()
	{
		foreach(Action action in actions){
			action.Setup();
		}
		base.Setup();
	}

	public override void RoundSetup ()
	{
		foreach(Action action in actions){
			action.RoundSetup();
		}
	}
}
