using UnityEngine;
using System.Collections;

public class InvisibleObjectsDestroyer : MonoBehaviour {
	//private Renderer _renderer;
    StateChanger _stateChanger;
    public TrailMaker trailMaker;
	// Use this for initialization
	void Start () {
		//_renderer = GetComponent<Renderer> ();
        _stateChanger = GetComponent<StateChanger>();
	}
	
	// Update is called once per frame
    void OnBecameInvisible()
    {
        if (TouchHandler.applicationIsRunning)
        {
            if (this.enabled)  // Otherwise this function is called when object is destroyed
            {

                Debug.Log("FuckME");

                Destroy(this.gameObject);
                _stateChanger.ChangeState();
            }
        }
    }
	void Update () {
		//if (!_renderer.isVisible) {
         //   Destroy(this.gameObject);
        //    _stateChanger.ChangeState();
        //
        //}
    
	}
    
}
