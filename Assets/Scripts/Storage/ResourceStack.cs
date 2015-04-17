using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceStack : AbstractStack<Resource> {
	public override void AddStock (Resource item)
	{
		base.AddStock (item);
		float height = transform.position.y;
		foreach(Resource resource in stock){
			height = Mathf.Max(resource.transform.position.y + 2f*resource.collider.bounds.extents.y,height);
		}
		height += 0.5f;

		item.transform.position = transform.position + transform.up*height;
		item.transform.rotation = transform.rotation;
		item.transform.parent = transform;
	}

	public override void RemoveStock ()
	{
		Resource item = stock.Pop();
		ResourcePool.ReturnResource(item);
	}
}
