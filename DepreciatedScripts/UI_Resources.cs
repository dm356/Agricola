using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UI_Resources : MonoBehaviour {
//	public Supply playerSupply;
	public Dictionary<Resource.ResourceType,TextMesh> displays;

	// Use this for initialization
	void Start () {
		// Set properly once organization is established
//		playerSupply = GameObject.Find("PlayerSupply").GetComponent<Supply>();
		displays = new Dictionary<Resource.ResourceType, TextMesh>();
		displays[Resource.ResourceType.Wood] = transform.FindChild("WoodDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Clay] = transform.FindChild("ClayDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Reed] = transform.FindChild("ReedDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Stone] = transform.FindChild("StoneDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Grain] = transform.FindChild("GrainDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Vegetable] = transform.FindChild("VegetableDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Sheep] = transform.FindChild("SheepDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Boar] = transform.FindChild("BoarDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Cow] = transform.FindChild("CowDisplay").GetComponent<TextMesh>();
		displays[Resource.ResourceType.Food] = transform.FindChild("FoodDisplay").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Resource.ResourceType type in Enum.GetValues(typeof(Resource.ResourceType))){
			displays[type].text = Supply.CheckStock(type).ToString();
		}
	}
}
