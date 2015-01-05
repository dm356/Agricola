using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceStorage : MonoBehaviour {
	
	public List<Transform> drop_locations;
	public Resource.ResourceType resource;
	private List<GameObject> stock;
	private int drop_index = 0;
	
	public int Count{
		get{
			return stock.Count;
		}
	}

	void Awake () {
		stock = new List<GameObject>();
	}

	public void AddStock(int amount){
		GameObject prefab = ResourceList.GetPrefab(resource);
		GameObject token;
		for(int i=0;i<amount;i++){
			token = GenerateToken(prefab);
			stock.Add(token);
		}
	}

	public void AddStock(GameObject token){
		Vector3 pos;
		Quaternion rot;
		nextLocation(out pos, out rot);
		token.transform.position = pos;
		token.transform.rotation = rot;
		stock.Add(token);
	}

	public void AddStock(List<GameObject> tokens){
		foreach(GameObject token in tokens){
			AddStock(token);
		}
	}

	public GameObject PullToken(){
		GameObject token = stock[Count-1];
		stock.RemoveAt(Count-1);
		return token;
	}

	public List<GameObject> PullStock(int amount){
		int start = Mathf.Max(0, Count-1-amount);
		List<GameObject> tokens = stock.GetRange(start,amount);
		stock.RemoveRange(start,amount);
		return tokens;
	}

	public List<GameObject> PullAll(){
		List<GameObject> tokens = PullStock(Count);
		return tokens;
	}

	public void RemoveStock(int amount){
		foreach(GameObject token in PullStock(amount)){
			Destroy(token);
		}
	}
	
	public void ClearStock(){
		foreach(GameObject item in stock){
			Destroy(item);
		}
		stock.Clear();
	}
	
	GameObject GenerateToken(GameObject prefab){
		Vector3 pos;
		Quaternion rot;
		nextLocation(out pos, out rot);
		GameObject token = Instantiate(prefab, pos, rot) as GameObject;
		return token;
	}

	void nextLocation(out Vector3 pos, out Quaternion rot){
		float height = transform.position.y + collider.bounds.extents.y;
		foreach(GameObject item in stock){
			height = Mathf.Max(item.transform.position.y + 2f*item.collider.bounds.extents.y,height);
		}
		height += 0.5f;
		pos = drop_locations[drop_index].position + drop_locations[drop_index].up*height;
		rot = drop_locations[drop_index].rotation;
		drop_index = (++drop_index) % drop_locations.Count;
	}
}
