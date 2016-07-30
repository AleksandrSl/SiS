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
            if (this.enabled)  // Otherwise this function is called when object is already destroyed
            {
                Destroy(this.gameObject);
                _stateChanger.ChangeState();
            }
        }
    }
    
}
