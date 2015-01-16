using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHandler : Singleton<PlayerHandler> {
	public List<PlayerFarm> farms;

	static Transform FarmView(int player){
		return Instance.farms[player].farm_view;
	}
}
