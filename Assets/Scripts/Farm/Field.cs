using UnityEngine;
using System.Collections;

public class Field : TokenStorage {

	public void SowResource(Resource.ResourceType resource, int count){
		GameObject token;
		for(int i=0;i<count;i++){
			token = Instantiate(ResourceList.GetPrefab(resource)) as GameObject;
			AddStock(token);
		}
	}

	public void HarvestResources(){
		RemoveTokens(1);
	}
}
