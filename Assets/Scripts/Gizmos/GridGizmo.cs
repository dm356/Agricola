using UnityEngine;
using System.Collections;

public class GridGizmo : MonoBehaviour
{
	void OnDrawGizmos()
	{
//		Gizmos.color = Color.black;
		Vector3 pos = transform.position, diff = Vector3.zero, siz = new Vector3(10f,0.2f,10f);
		for(float i=0f;i<=4f;i+=1f){
			for(float j=0f;j<=2f;j+=1f){
				diff.x = i*transform.lossyScale.x;
				diff.z = j*transform.lossyScale.z;
//				Gizmos.DrawSphere(pos + diff,1f);
				Gizmos.DrawWireCube(pos + transform.rotation*diff, siz);
			}
		}
	}
}
