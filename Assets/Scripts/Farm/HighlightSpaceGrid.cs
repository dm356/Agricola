using UnityEngine;
using System.Collections;

public class HighlightSpaceGrid : MonoBehaviour
{
	private GameObject[,] grid_instances;

	// Use this for initialization
	void Start ()
	{
//		Console.addConsoleFunction ("highlight", consoleHighlight);
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public void SetupTiles (GameObject highlight_prefab)
	{
		grid_instances = new GameObject[3, 5];
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 5; j++) {
				grid_instances [i, j] = Instantiate (highlight_prefab, gridPoint (i, j), Quaternion.identity) as GameObject;
				grid_instances [i, j].SetActive (false);
				grid_instances [i, j].transform.SetParent (transform);
			}
		}
	}

	public void Highlight (bool on, int row, int col)
	{
		grid_instances [row, col].SetActive (on);
	}

	public bool isHighlighted (int row, int col)
	{
		return grid_instances [row, col].activeSelf;
	}

	public Vector3 gridPoint (int row, int col)
	{
		Vector3 pos = transform.position;
		Vector3 diff = Vector3.zero;
		diff.x = col * transform.lossyScale.x;
		diff.z = row * transform.lossyScale.z;
		return pos + transform.rotation * diff;
	}

	void consoleHighlight (string[] command)
	{
		bool valid = true;
		if (command [0].Equals ("highlight", System.StringComparison.Ordinal)) {
			if (command.Length < 2) {
				valid = false;
			} else {
				if (command [1].Equals ("all", System.StringComparison.Ordinal)) {
					for (int i = 0; i < 3; i++) {
						for (int j = 0; j < 5; j++) {
							Highlight (true, i, j);
						}
					}
				} else if (command [1].Equals ("none", System.StringComparison.Ordinal)) {
					for (int i = 0; i < 3; i++) {
						for (int j = 0; j < 5; j++) {
							Highlight (false, i, j);
						}
					}
				} else if (command.Length < 3) {
					valid = false;
				} else {
					try {
						int row = int.Parse (command [1]);
						int col = int.Parse (command [2]);
						bool on = !isHighlighted (row, col);
						Highlight (on, row, col);
					} catch (System.FormatException) {
						valid = false;
					}
		
				}
			}
			if (!valid)
				Debug.LogError ("Highlight command improperly entered.  Should be => highlight [row] [col] to highlight player farm tile.");
		} else {
			Debug.LogError ("Unknown command.");
		}
	}
}
