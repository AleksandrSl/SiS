using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;


class RotationController : MonoBehaviour{

	public void OnRotationCommand(Vector2 coord_2d){

		Vector3 coord_3d_ = new Vector3 (coord_2d.x, coord_2d.y, 0);
		float speed_ = 8f;

		//Debug.Log("Rotation Started");
		Quaternion clickRotation_ = Quaternion.LookRotation (Vector3.forward, coord_3d_ - transform.position);

		if (clickRotation_ != transform.rotation) { //Is't worth to do so?
		
			transform.rotation = Quaternion.Slerp (transform.rotation, clickRotation_, speed_ * Time.deltaTime);
		}
	}

	void Awake(){
		Controller.Rotate.Subscribe (OnRotationCommand);
	}

}