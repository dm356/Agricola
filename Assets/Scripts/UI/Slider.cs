using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {
	public GameObject gui_object;
	public Transform hide_location;
	public float speed_limit;
	public bool hidden = true;

	void Update(){
		Transform target;
		if(hidden){
			target = hide_location;
		}else{
			target = transform;
		}

		float travel_time = (gui_object.transform.position-target.position).magnitude/speed_limit;
		if(travel_time > 0){
			float rotation_speed = Quaternion.Angle(gui_object.transform.rotation,target.rotation)/travel_time;
			gui_object.transform.position = Vector3.MoveTowards(gui_object.transform.position,target.position,speed_limit);
			gui_object.transform.rotation = Quaternion.RotateTowards(gui_object.transform.rotation,target.rotation, rotation_speed);
		}
	}
}
