using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnAimCollision : MonoBehaviour {
    public TrailHandler trailHandler;
    
    List<Vector2> path = null;
    
    public void moveToShip()
    {
        path = trailHandler.getPath();
        path.Reverse();
        Debug.Log("PAth is here");

        foreach (Vector2 point in path)
        {
            transform.position = Vector2.Lerp(transform.position, point, 0.9f);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
