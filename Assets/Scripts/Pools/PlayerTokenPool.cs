using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enum = System.Enum;

public class PlayerTokenPool : Singleton<PlayerTokenPool> {
	public List<GameObject> token_prefabs;
	private List<AbstractPool<PlayerToken>> pool;

	void Awake () {
		pool = new List<AbstractPool<PlayerToken>>();
		for(int i=0;i<token_prefabs.Count;i++){
			pool.Add(new AbstractPool<PlayerToken>(token_prefabs[i]));
		}
	}

	public static void GetToken(int player){
		PlayerToken token = Instance.pool[player].GetItem();
		token.gameObject.SetActive(true);
	}

	public static void ReturnToken(PlayerToken token){
		token.gameObject.SetActive(false);
		Instance.pool[token.player_id].ReturnItem(token);
	}
}
