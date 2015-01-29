using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFarm : MonoBehaviour {
	public Transform farm_view;
	public House house;
	public PlayerSupply supply;

	public GameObject TakeFamily(){
		return house.PullToken();
	}

	public int ResourceCount(Resource.ResourceType resource){
		return supply.ResourceCount(resource);
	}

	public void AddResources(List<GameObject> tokens){
		supply.AddStock(tokens);
	}
}
