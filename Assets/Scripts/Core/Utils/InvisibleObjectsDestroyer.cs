using UnityEngine;
using System.Collections;


public class InvisibleObjectsDestroyer : MonoBehaviour {
	
    private StateChanger _stateChanger;
	
	void Start ()
    {
        _stateChanger = GetComponent<StateChanger>();
	}
	
	// Update is called once per frame
    void OnBecameInvisible()
    {
        if (TouchHandler.applicationIsRunning)
        {
            if (this.enabled)  // Otherwise this function is called when object is destroyed
            {
                Destroy(this.gameObject);
                //_stateChanger.ChangeState();
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
