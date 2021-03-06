﻿using UnityEngine;
using System.Collections;

public class RoundCard : ActionSpace {

	protected bool active;
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

	public override void RoundSetup ()
	{
		if(active){
			base.RoundSetup ();
		}
	}
}
