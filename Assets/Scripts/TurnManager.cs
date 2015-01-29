using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : Singleton<TurnManager> {

	private int current_player = 0;
	private int current_round = 0;
	private int current_stage = 0;
	public int num_players = 0;
	public List<Stage> stages;

	public static int CurrentPlayer{
		get{
			return Instance.current_player;
		}
	}

	public static int round{
		get{
			return Instance.current_round;
		}
	}

	public static int stage{
		get{
			return Instance.current_stage;
		}
	}

	public static void CyclePlayers(){
		Instance.current_player += 1;
		if(Instance.current_player > Instance.num_players-1){
			Instance.current_player = 0;
		}
		if(Instance.current_player == PlayerInput.Id){
			PlayerInput.SetFlag(PlayerInput.InputState.PlaceToken,true);
		}
	}

	public static void NextRound(){
		Instance.current_round++;
		if(Instance.current_round == 1 || Instance.current_round == 5 || Instance.current_round == 8 || Instance.current_round == 10 || Instance.current_round == 12 || Instance.current_round == 14){
			Instance.current_stage += 1;
		}

		Instance.stages[Instance.current_stage-1].Activate(Instance.current_round);

		if(Instance.current_player == PlayerInput.Id){
			PlayerInput.SetFlag(PlayerInput.InputState.PlaceToken,true);
		}
	}
}
