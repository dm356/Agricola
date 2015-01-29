using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHandler : Singleton<PlayerHandler> {
	public List<PlayerFarm> farms;
	public bool active;

	public static Transform FarmView(int player){
		return Instance.farms[player].farm_view;
	}

	public static GameObject GetCurrentPlayerToken(){
		return Instance.farms[TurnManager.CurrentPlayer].TakeFamily();
	}

	public static int ActivePlayerResourceCount(Resource.ResourceType resource){
		return Instance.farms[PlayerInput.Id].ResourceCount(resource);
	}

	public static void CurrentPlayerAddStock(List<GameObject> tokens){
		Instance.farms[TurnManager.CurrentPlayer].AddResources(tokens);
	}
}
