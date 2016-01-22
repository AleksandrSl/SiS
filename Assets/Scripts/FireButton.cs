using UnityEngine;
using System.Collections;

public class FireButton : MonoBehaviour {

	public void OnClick(){
		if (this.enabled) {
			Controller.Fire.Say ();
		}
	}
}
