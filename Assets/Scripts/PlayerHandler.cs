using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHandler : Singleton<PlayerHandler>
{
	public List<PlayerFarm> farms;

	public static bool CurrentPlayerRoundFinished ()
	{
		return Instance.farms [TurnManager.CurrentPlayer].FamilyCount () == 0;
	}

	public static bool AllPlayersRoundFinished ()
	{
		foreach (PlayerFarm farm in Instance.farms) {
			if (farm.FamilyCount () > 0)
				return false;
		}
		return true;
	}

	public static PlayerFarm CurrentPlayerFarm {
		get {
			return Instance.farms [TurnManager.CurrentPlayer];
		}
	}
	//
	//	public static House CurrentPlayerHouse {
	//		get {
	//			return Instance.farms [TurnManager.CurrentPlayer].house;
	//		}
	//	}
	//
	//	public static FieldHandler CurrentPlayerFields {
	//		get {
	//			return Instance.farms [TurnManager.CurrentPlayer].fields;
	//		}
	//	}

	public static Transform FarmView (int player)
	{
		return Instance.farms [player].farm_view;
	}

	public static GameObject GetCurrentPlayerToken ()
	{
		return Instance.farms [TurnManager.CurrentPlayer].TakeFamily ();
	}

	public static int ActivePlayerResourceCount (ResourceType resource)
	{
		return Instance.farms [PlayerInput.Id].ResourceCount (resource);
	}

//	public static void CurrentPlayerAddStock(List<GameObject> tokens){
//		Instance.farms[TurnManager.CurrentPlayer].AddResources(tokens);
//	}

	public static void CurrentPlayerAddResources (ResourceType resource, int amount)
	{
		Instance.farms [TurnManager.CurrentPlayer].AddResources (resource, amount);
	}

	public static void ReturnFamily (GameObject token)
	{
		PlayerToken pt = token.GetComponent<PlayerToken> ();
		if (pt) {
			Instance.farms [pt.player_id].AddFamily (token);
		}
	}
}
