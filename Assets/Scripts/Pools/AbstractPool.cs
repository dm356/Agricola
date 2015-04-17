using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AbstractPool<T> where T : MonoBehaviour{
	public GameObject _prefab;
	private Stack<T> pool;

	public AbstractPool(GameObject prefab){
		_prefab = prefab;
		pool = new Stack<T>();
	}

	public GameObject Prefab{
		get{
			return _prefab;
		}
	}

	public T GetItem(){
		if(pool.Count > 0){
			return pool.Pop();
		}else{
			GameObject obj = GameObject.Instantiate(_prefab) as GameObject;
			return obj.GetComponent<T>();
		}
	}

	public void ReturnItem(T item){
		pool.Push(item);
	}
}