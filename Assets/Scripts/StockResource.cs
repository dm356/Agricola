using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StockResource : MonoBehaviour {

	public List<Transform> drop_locations;
	public Resource.ResourceType resource;
	public int gain = 0;
	private List<GameObject> stock;
	private int drop_index = 0;

	public int Count{
		get{
			return stock.Count;
		}
	}
	
	// Use this for initialization
	void Start () {
		stock = new List<GameObject>();
//		drop_location = transform.FindChild("ResourceStack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restock(){
		GameObject prefab = ResourceList.GetPrefab(resource);
		GameObject token;
		float height = transform.position.y + collider.bounds.extents.y;
		foreach(GameObject item in stock){
			height = Mathf.Max(item.transform.position.y + 2f*item.collider.bounds.extents.y,height);
		}
		height += 0.5f;
		for(int i=0;i<gain;i++){
			token = GenerateToken(prefab, height) ;
			height += token.collider.bounds.extents.y*2f;
			stock.Add(token);
		}
	}

	public void ClearStock(){
		foreach(GameObject item in stock){
			Destroy(item);
		}
		stock.Clear();
	}


	GameObject GenerateToken(GameObject prefab, float height){
		GameObject token = Instantiate(prefab, drop_locations[drop_index].position + drop_locations[drop_index].up*height, drop_locations[drop_index].rotation) as GameObject;
		drop_index = (++drop_index) % drop_locations.Count;
		return token;
	}
}
