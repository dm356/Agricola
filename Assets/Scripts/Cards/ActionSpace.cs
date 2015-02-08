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
		PlayerInput.SetFlag(PlayerInput.InputState.PlaceToken, false);
	}

	public virtual void ExecuteAction(){
		if(activated_action){
			activated_action.Execute();
		}
	}

	public void CancelAction(){
		PlayerHandler.ReturnFamily(player_stack.PullToken());
	}

	public virtual void RoundSetup(){
		if(activated_action){
			activated_action.RoundSetup();
		}
	}

	public virtual void RoundClear(){
		foreach(GameObject token in player_stack.PullAll()){
			PlayerHandler.ReturnFamily(token);
		}
	}
}
