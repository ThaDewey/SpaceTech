using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Containers
{
	public override void OnOpen() {
		base.OnOpen();
		Debug.Log("Open Chest");
	}
	public override void OnClose() {
		base.OnClose();
		Debug.Log("Close Chest");
	}

}
