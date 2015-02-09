﻿using UnityEngine;
using System.Collections;

public class Room : RecursiveStorage {

	private House.HouseType _type;
	public MeshRenderer model;
	public Material wood;
	public Material clay;
	public Material stone;

	[HideInInspector]
	public int x;
	[HideInInspector]
	public int y;

	public House.HouseType type{
		get{
			return _type;
		}
		set{
			_type = value;
			if(value == House.HouseType.Wood){
				model.material = wood;
			}else if(value == House.HouseType.Clay){
				model.material = clay;
			}else if(value == House.HouseType.Stone){
				model.material = stone;
			}
		}
	}
}
