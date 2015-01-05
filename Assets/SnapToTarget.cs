using UnityEngine;
using System.Collections;

public class SnapToTarget : MonoBehaviour {

	public Transform target;
	public float speed_limit;
	public float rotation_limit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target){
			transform.position = Vector3.Lerp(transform.position,target.position,speed_limit);
			transform.rotation = Quaternion.Slerp(transform.rotation,target.rotation, rotation_limit);
		}
	}
}
