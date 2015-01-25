using UnityEngine;
using System.Collections;

public class ActionSpace : MonoBehaviour {

	public AbstractStorage player_stack;
	public Action activated_action;

	public virtual void SetupAction(){
		Interface.awaitConfirmation(this);
		if(activated_action){
			activated_action.Setup();
		}
		GameObject token = Supply.GetPlayerToken();
		player_stack.AddStock(token);
	}

	public virtual void ExecuteAction(){
		if(activated_action){
			activated_action.Execute();
		}
	}

	public void CancelAction(){
		player_stack.RemoveTokens(1);
	}
}
