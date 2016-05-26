using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceStack : MonoBehaviour
{

	public ResourceType type;
	private Stack<GameObject> stack = new Stack<GameObject> ();
	private List<Vector3> position_list = new List<Vector3> ();
	private int position_index = 0;

	private StorageCounter counter = null;

	public int Count {
		get {
			return stack.Count;
		}
	}

	public void SetCounter (StorageCounter c)
	{
		counter = c;
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		while (Count > counter.Count) {
			RemoveResource ();
		}
		while (Count < counter.Count) {
			AddResource ();
		}
	}

	public void AddStackPosition (Vector3 position)
	{
		position_list.Add (position);
	}

	void AddResource ()
	{
		position_index += 1;
		if (position_list.Count < 1) {
			Debug.Log ("No position set.");
			return;
		} else if (position_index > position_list.Count - 1) {
			position_index = 0;
		}
		GameObject new_item = PoolManager.GetResource (type);
		float height = transform.position.y;
		Vector3 itemext = new_item.GetComponent<Collider> ().bounds.extents;
		foreach (GameObject item in stack) {
			height = Mathf.Max (item.transform.position.y + 2f * itemext.y, height);
		}
		height += 0.5f;

		new_item.transform.position = transform.position + transform.up * height + position_list [position_index];
		new_item.transform.rotation = transform.rotation;
		new_item.transform.SetParent (transform);
		stack.Push (new_item);
	}

	void RemoveResource ()
	{
		if (Count > 0)
			PoolManager.ReturnResource (type, stack.Pop ());
	}
}
