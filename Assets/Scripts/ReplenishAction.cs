using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReplenishAction : MonoBehaviour {

	public List<StockResource> resource_cards;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReplenishResources(){
		foreach(StockResource stock in resource_cards){
			stock.Restock();
		}
	}
}
