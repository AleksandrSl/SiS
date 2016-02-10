using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;


class RotationController : MonoBehaviour{

    public float speed_ = 8f;
    public void OnRotationCommand(Vector2 coord_2d){
        if (enabled)
        {
            Vector3 coord_3d_ = new Vector3(coord_2d.x, coord_2d.y, 0);
            

            //Debug.Log("Rotation Started");
            Quaternion clickRotation_ = Quaternion.LookRotation(Vector3.forward, coord_3d_ - transform.position);
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (clickRotation_ != transform.rotation)
                { //Is't worth to do so?

                    transform.rotation = Quaternion.Slerp(transform.rotation, clickRotation_, speed_ * Time.deltaTime);
                }
            }
        }
	}

	void Awake(){
		Controller.Rotate.Subscribe (OnRotationCommand);
	}
    void Update() { }
}