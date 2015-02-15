using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFarm : MonoBehaviour {
	public Transform farm_view;
	public House house;
	public PlayerSupply supply;
	public FieldHandler fields;

	public int FamilyCount(){
		return house.Count;
	}

	public GameObject TakeFamily(){
		if(FamilyCount() > 0){
			return house.PullToken();
		}else{
			return null;
		}
	}

	public void AddFamily(GameObject token){
		house.AddStock(token);
	}

	public int ResourceCount(Resource.ResourceType resource){
		return supply.ResourceCount(resource);
	}

	public void AddResources(List<GameObject> tokens){
		supply.AddStock(tokens);
	}

	public void AddResources(Resource.ResourceType resource, int amount){
		supply.AddResources(resource,amount);
	}
}
