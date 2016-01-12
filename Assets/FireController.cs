using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	public Rigidbody2D missile;
	public void OnFire(){
		Rigidbody2D missileCopy = Instantiate(missile, transform.position, transform.rotation) as Rigidbody2D;
		missileCopy.velocity = transform.up*10f;
	}


	void Awake(){
		Controller.Fire.Subscribe (OnFire);
	}
}
