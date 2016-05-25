using UnityEngine;
using System.Collections;

public class UI_CounterWindow : MonoBehaviour
{
	public GameObject counter_prefab;
	public float spacing;

	// Use this for initialization
	void Start ()
	{
		float ypos = (Resource.numResources - 1f) / 2f * spacing;
		UI_ResourceCounter counter_controller = counter_prefab.GetComponent<UI_ResourceCounter> ();
		foreach (ResourceType t in Resource.TypeIterator()) {
			if (Resource.IsAnimal (t)) {
				counter_controller.animal = true;
			} else {
				counter_controller.animal = false;
			}
			GameObject counter = Instantiate (counter_prefab) as GameObject;
			counter.transform.position = new Vector3 (0f, ypos, 0f);
			counter.transform.SetParent (transform, false);
			counter.GetComponent<UI_ResourceCounter> ().resource = t;
			ypos -= spacing;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
