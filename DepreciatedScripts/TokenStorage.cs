using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TokenStorage : AbstractStorage {
	
	private List<TokenStack> stacks;
	
	public override int Count{
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
	
	public override void AddStock(GameObject token){
		TokenStack min_stack = null;
		int min_count = 1000000;
		foreach(TokenStack stack in stacks){
			if(stack.Count < min_count){
				min_count = stack.Count;
				min_stack = stack;
			}
		}
		min_stack.AddStock(token);
	}
	
	public override GameObject PullToken(){
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
}
