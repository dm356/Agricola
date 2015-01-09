using UnityEngine;
using System.Collections;

public class SupplyGizmo : MonoBehaviour {
	public PlayerSupply supply;

	void OnDrawGizmos()
	{
		Vector3 pos = transform.position, diff = Vector3.zero, siz = new Vector3(9f,0.2f,9f);
		for(float i=-3f;i<=3f;i+=1f){
			diff.x = i*supply.spacing;
			Gizmos.DrawWireCube(pos + transform.rotation*diff, siz);
		}
	}
}
