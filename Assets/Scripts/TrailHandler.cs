using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using StateMachine;


public class TrailHandler : MonoBehaviour {

    List<GameObject>[] _trails = new List<GameObject>[3];
    int _count = 0;
    public GameObject dotPrefab;
    void Awake() {
        _trails[0] = new List<GameObject>();
        _trails[1] = new List<GameObject>();
        _trails[2] = new List<GameObject>();

        TrailMaker.trail.Subscribe(addTrail);
        
    }
    
    void addTrail(List<GameObject> trail)
    {
        deleteTrail(_trails[_count]);
        _trails[_count] = trail;
        Debug.Log("Added");
        //_count++;
        
        
        
    }
    void deleteTrail(List<GameObject> trail)
    {
        if (trail.Count != 0)
        {
            foreach (GameObject dot in trail)
            {

                Destroy(dot);
            }
            Debug.Log("Destroyed");
            trail.Clear();
            //_count--;
        }
    }
    public void winTrail() {
        Debug.Log("FuckMe");
        foreach (GameObject dot in _trails[_count])
        {
            
            Vector2 pos = dot.transform.position;
            Destroy(dot);
            GameObject winDot = Instantiate(dotPrefab, pos, Quaternion.identity) as GameObject;
            //Destroy(winDot);
                        
        }
    }
        
    
}
