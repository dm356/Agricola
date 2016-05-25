using UnityEngine;
using System.Collections;

public class Room : RecursiveStorage<PlayerToken>
{
	private ResourceType _type;
	public MeshRenderer model;
	public Material wood;
	public Material clay;
	public Material stone;
	//
	//	[HideInInspector]
	//	public int x;
	//	[HideInInspector]
	//	public int y;

	public ResourceType type {
		get {
			return _type;
		}
		set {
			_type = value;
			if (value == ResourceType.Wood) {
				model.material = wood;
			} else if (value == ResourceType.Clay) {
				model.material = clay;
			} else if (value == ResourceType.Stone) {
				model.material = stone;
			}
		}
	}
}
