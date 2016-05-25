using UnityEngine;
using System.Collections;

public abstract class Action
{
	public string name;

	public Action ()
	{
	}

	public virtual int ResourceModifier (ResourceType resource)
	{
		return 0;
	}

	//	public virtual bool Valid{
	//		get{
	//			return true;
	//		}
	//	}

	//	public virtual void Setup(){Interface.ShowButtons(true);}

	public abstract void Execute ();
	//
	//	public virtual void Cancel(){}
	//
	//	public virtual void RoundSetup(){}
}
