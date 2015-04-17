using UnityEngine;
using System.Collections;

public class TakeResource : Action {
	public Resource.ResourceType _resource;
	public int _amount;

	public TakeResource(Resource.ResourceType resource, int amount):base(){
		_resource = resource;
		_amount = amount;
	}

	public override int ResourceModifier (Resource.ResourceType resource)
	{
		int modifier = base.ResourceModifier (resource);
		if(resource == _resource){
			modifier += _amount;
		}
		return modifier;
	}

	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerAddResources(_resource,_amount);
	}
}
