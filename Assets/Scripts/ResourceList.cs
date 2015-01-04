using UnityEngine;
using System.Collections;

public class ResourceList : Singleton<ResourceList> {

	public GameObject wood;
	public GameObject clay;
	public GameObject reed;
	public GameObject stone;
	public GameObject grain;
	public GameObject vegetable;
	public GameObject sheep;
	public GameObject boar;
	public GameObject cow;
	public GameObject food;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject GetPrefab(Resource.ResourceType resource){
		switch(resource){
			case Resource.ResourceType.Wood:
				return Instance.wood;
			case Resource.ResourceType.Clay:
				return Instance.clay;
			case Resource.ResourceType.Reed:
				return Instance.reed;
			case Resource.ResourceType.Stone:
				return Instance.stone;
			case Resource.ResourceType.Grain:
				return Instance.grain;
			case Resource.ResourceType.Vegetable:
				return Instance.vegetable;
			case Resource.ResourceType.Sheep:
				return Instance.sheep;
			case Resource.ResourceType.Boar:
				return Instance.boar;
			case Resource.ResourceType.Cow:
				return Instance.cow;
			case Resource.ResourceType.Food:
				return Instance.food;
		}
		return null;
	}
}
