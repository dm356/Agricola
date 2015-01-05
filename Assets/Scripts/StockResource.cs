using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StockResource : ResourceStorage {
	public int gain = 0;

	public void Restock(){
		AddStock(gain);
	}
}
