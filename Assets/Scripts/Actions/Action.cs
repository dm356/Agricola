using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

	private bool awaiting_confirmation = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Setup(){}

	public abstract void Execute();
}
