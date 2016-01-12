using UnityEngine;
using System.Collections;

public class FireButton : MonoBehaviour {

	public void OnClick(){
		Controller.Fire.Say ();
	}
}
