using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage : MonoBehaviour {
	public List<GameObject> card_prefabs;
	public List<Transform> locations;
	public int first_round;
	private List<RoundCard> rounds;

	void Awake(){
		Deal();
	}

	public void Deal(){
		rounds = new List<RoundCard>();
		int index;
		GameObject card;
		foreach(Transform location in locations){
			index = Mathf.FloorToInt(Random.Range(0f,(float) card_prefabs.Count - 0.1f));
			card = Instantiate(card_prefabs[index],location.position,location.rotation) as GameObject;
			card.transform.parent = transform;
			rounds.Add(card.GetComponent<RoundCard>());
			card_prefabs.RemoveAt(index);
		}
	}

	public void Activate(int round){
		rounds[round-first_round].Activate();
	}
}
