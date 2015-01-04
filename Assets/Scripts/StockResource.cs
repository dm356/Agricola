using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StockResource : MonoBehaviour {

	private Transform drop_location;
	public GameObject resource;
	public int gain = 0;
	private List<GameObject> stock;

	public int Count{
		get{
			return stock.Count;
		}
	}
	
	// Use this for initialization
	void Start () {
		stock = new List<GameObject>();
		drop_location = transform.FindChild("ResourceStack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restock(){
		GameObject token;
		float height = resource.transform.lossyScale.y*(0.5f + 2f*((float) Count)) + 0.5f;
		for(int i=0;i<gain;i++){
			token = Instantiate(resource, drop_location.position + drop_location.up*height, drop_location.rotation) as GameObject;
			stock.Add(token);
			height += resource.transform.lossyScale.y*2f;
		}
	}

	public void ClearStock(){
		foreach(GameObject item in stock){
			Destroy(item);
		}
		stock.Clear();
	}
}
