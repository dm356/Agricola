using UnityEngine;
using System.Collections;

public class ActionSpace : MonoBehaviour {

	public AbstractStorage player_stack;
	public Action activated_action;

	public bool Occupied{
		get{
			return player_stack.Count > 0;
		}
	}

	public virtual void SetupAction(){
		Interface.awaitConfirmation(this);
		if(activated_action){
			activated_action.Setup();
		}
		player_stack.AddStock(PlayerHandler.GetCurrentPlayerToken());
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
