using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldHandler : MonoBehaviour {

	private List<Field> fields;
	public FarmGrid grid;
	public GameObject field_prefab;

	void Start(){
		fields = new List<Field>();
	}

	public void SpawnField(int row, int col){
		GameObject field = Instantiate(field_prefab) as GameObject;
		grid.AssignToGrid(field,row,col);
		field.transform.parent = transform;
		Field fclass = field.GetComponent<Field>();
		fields.Add(fclass);
	}

	public void PlowFields(){
		grid.Activate(field_prefab,Tile.TileType.None, FarmGridSpace.Location.Tile);
		PlayerInput.SetFlag(PlayerInput.InputState.FarmAction,true);
	}

	public void SetFields(){
		grid.buildFieldsFromSelected(this);
		ClearSelectables();
	}

	public void ClearSelectables(){
		grid.Deactivate();
		PlayerInput.SetFlag(PlayerInput.InputState.FarmAction,false);
	}

	public void SowFields(){
		grid.Activate(ResourceList.GetPrefab(Resource.ResourceType.Grain),Tile.TileType.Field, FarmGridSpace.Location.Resource);
		PlayerInput.SetFlag(PlayerInput.InputState.FarmAction,true);
	}
}
