using UnityEngine;
using System.Collections;

public class UI_Cancel : UI_Action {

	public override void Execute ()
	{
		Interface.Cancel();
	}
}
