using UnityEngine;
using System.Collections;

public class TakeResource : Action {
	public Resource.ResourceType resource;
	public int amount;

	public override void Setup ()
	{
		Interface.setModifier(resource,amount);
		base.Setup();
	}
	
	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerAddResources(resource,amount);
	}
}
