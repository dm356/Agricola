using UnityEngine;
using System.Collections;

public class TurnManager : Singleton<TurnManager> {

	private int current_player = 0;

	public static int CurrentPlayer{
		get{
			return Instance.current_player;
		}
	}
}
