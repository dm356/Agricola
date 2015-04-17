using UnityEngine;
using System.Collections;

public class Room : RecursiveStorage<PlayerToken> {

	private Resource.ResourceType _type;
	public MeshRenderer model;
	public Material wood;
	public Material clay;
	public Material stone;
//
//	[HideInInspector]
//	public int x;
//	[HideInInspector]
//	public int y;

	public Resource.ResourceType type{
		get{
			return _type;
		}
		set{
			_type = value;
			if(value == Resource.ResourceType.Wood){
				model.material = wood;
			}else if(value == Resource.ResourceType.Clay){
				model.material = clay;
			}else if(value == Resource.ResourceType.Stone){
				model.material = stone;
			}
		}
	}
}
