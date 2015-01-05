using UnityEngine;
using System.Collections;

public class SnapToTarget : MonoBehaviour {

	public Transform target;
	public float speed_limit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target){
			float travel_time = (transform.position-target.position).magnitude/speed_limit;
			float rotation_speed = Quaternion.Angle(transform.rotation,target.rotation)/travel_time;
			transform.position = Vector3.MoveTowards(transform.position,target.position,speed_limit);
			transform.rotation = Quaternion.RotateTowards(transform.rotation,target.rotation, rotation_speed);
		}
	}
}
