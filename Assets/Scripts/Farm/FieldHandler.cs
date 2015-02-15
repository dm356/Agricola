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
//		fclass.x = row;
//		fclass.y = col;
		fields.Add(fclass);
//		fclass.type = type;
	}

	public void PlowFields(){
		grid.Activate(field_prefab,Tile.TileType.None);
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
}
