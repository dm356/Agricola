using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

	public string name = "";

	private bool awaiting_confirmation = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Setup(){Interface.ShowButtons(true);}

	public abstract void Execute();

	public virtual void RoundSetup(){}
}
