using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

	public string name = "";

	public virtual bool Valid{
		get{
			return true;
		}
	}

	public virtual void Setup(){Interface.ShowButtons(true);}

	public abstract void Execute();

	public virtual void Cancel(){}

	public virtual void RoundSetup(){}
}
