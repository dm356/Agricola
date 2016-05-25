using UnityEngine;
using System.Collections;

public class TakeResource : Action
{
	public ResourceType resource;
	public int amount;

	public override bool Valid {
		get {
			if (PlayerHandler.ActivePlayerResourceCount (resource) + amount < 0) {
				return false;
			}
			return base.Valid;
		}
	}

	public override void Setup ()
	{
		Interface.setModifier (resource, amount);
		base.Setup ();
	}

	public override void Execute ()
	{
		PlayerHandler.CurrentPlayerAddResources (resource, amount);
	}
}
