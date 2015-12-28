﻿using UnityEngine;
using System.Collections;


class ObjectRotationController : MonoBehaviour{
	private Transform _transform;
	public void OnRotationCommand(Vector2 coord){
		Vector2.Lerp (_transform.rotation, coord, 0.5f);

	}


	void Awake(){
		Controller.Rotate.Subscribe(OnRotationCommand);	 ublic float direcCo]
		_transform = GetComponent<Transform>();
	}
}