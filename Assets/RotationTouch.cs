using UnityEngine;
using System.Collections;

public class RotationTouch : MonoBehaviour {
	Vector2 touchCoord;
	// Use this for initialization

	//public float direction = 1.0f;

	// Update is called once per frame
	void Update () {
		touchCoord = Input.GetTouch().position;
		Controller.Rotate.Say (touchCoord);
	}
}
