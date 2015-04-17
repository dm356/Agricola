using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceStorage : RecursiveStorage<Resource> {
	
	public Resource.ResourceType resource;
	
	public void AddStock(int amount){
		if(amount > 0){
//			GameObject prefab = ResourceList.GetPrefab(resource);
//			GameObject token;
			for(int i=0;i<amount;i++){
//				token = Instantiate(prefab) as GameObject;
				AddStock(ResourcePool.GetResource(resource));
			}
		}else if(amount < 0){
			RemoveTokens(-amount);
		}
	}

	public override void AddStock(GameObject token){
		// Check token resource
		if(token.GetComponent<Resource>().type == resource){
			base.AddStock(token);
		}else{
			Debug.Log("ResourceStorage ERROR: Wrong resource token added");
		}
	}
}
