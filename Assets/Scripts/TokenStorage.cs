using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TokenStorage : MonoBehaviour {
	
	private List<TokenStack> stacks;
	private int drop_index = 0;
	
	public int Count{
		get{
			int n = 0;
			foreach(TokenStack stack in stacks){
				n += stack.Count;
			}
			return n;
		}
	}
	
	void Start () {
		stacks = new List<TokenStack>();
		TokenStack stack;
		foreach(Transform child in transform){
			stack = child.GetComponent<TokenStack>();
			if(stack){
				stacks.Add(stack);
			}
		}
	}
	
	public virtual void AddStock(GameObject token){
		stacks[drop_index].AddStock(token);
		drop_index = (++drop_index) % stacks.Count;
	}
	
	public void AddStock(List<GameObject> tokens){
		foreach(GameObject token in tokens){
			AddStock(token);
		}
	}
	
	public GameObject PullToken(){
		TokenStack max_stack = null;
		int max_count = 0;
		foreach(TokenStack stack in stacks){
			if(stack.Count > max_count){
				max_count = stack.Count;
				max_stack = stack;
			}
		}
		
		if(max_stack){
			return max_stack.PullToken();
		}else{
			Debug.Log("TokenStack.PullToken ERROR: No tokens left");
			return null;
		}
	}
	
	public List<GameObject> PullStock(int amount){
		List<GameObject> tokens = new List<GameObject>();
		for(int i=0;i<amount;i++){
			tokens.Add(PullToken());
		}
		return tokens;
	}
	
	public List<GameObject> PullAll(){
		List<GameObject> tokens = PullStock(Count);
		return tokens;
	}
	
	public void RemoveStock(int amount){
		foreach(GameObject token in PullStock(amount)){
			Destroy(token);
		}
	}
	
	public void ClearStock(){
		foreach(TokenStack stack in stacks){
			stack.ClearStock();
		}
	}
}
