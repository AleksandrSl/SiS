using UnityEngine;
using System.Collections;

public class InvisibleObjectsDestroyer : MonoBehaviour {
	private Renderer _renderer;
	// Use this for initialization
	void Start () {
		_renderer =this.gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_renderer.isVisible) {
			Debug.Log("I'm Destroyed");
			Destroy(this.gameObject);
		}
	}
}
