using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {



	private House.HouseType _type;
	public MeshRenderer model;
	public Material wood;
	public Material clay;
	public Material stone;

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
