using UnityEngine;
using System.Collections;

public class RoundCard : ActionSpace {

	private bool active;
	public MeshRenderer model;
	public Material card_face;

	public virtual void Activate(){
		if(!active){
			model.material = card_face;
			active = true;
		}
	}

	public override void SetupAction ()
	{
		if(active){
			base.SetupAction ();
		}
	}
}
