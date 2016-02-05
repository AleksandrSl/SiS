using UnityEngine;
using System.Collections;

public class InvisibleObjectsDestroyer : MonoBehaviour {
	private Renderer _renderer;
    private StateChanger _stateChanger;
	// Use this for initialization
	void Start () {
		_renderer =this.gameObject.GetComponent<Renderer> ();
        _stateChanger = this.gameObject.GetComponent<StateChanger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_renderer.isVisible) {
			//Debug.Log("I'm Destroyed");
            Destroy(this.gameObject);
            
		}
    
	}
    void OnDestroy() {
        _stateChanger.ChangeState();
    }
}
