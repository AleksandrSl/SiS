using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrailMaker : MonoBehaviour {
    public static SingleMessage<List<GameObject>> trail = new SingleMessage<List<GameObject>>();
    public static SingleMessage<List<Vector2>> transformTrail = new SingleMessage<List<Vector2>>();
    List<GameObject> _trail = new List<GameObject>();
    List<Vector2> _transformTrail = new List<Vector2>();

    
    public float density;
    public GameObject dotPrefab1;
    public GameObject dotPrefab2;
    public float firstDot;
    float _nextDot;
    Vector3 _pos = Vector3.zero;
    bool _trailSended = false;
    Movable _mov;
    int _counter;
   
	void Awake()
    {
        _nextDot = firstDot;
        _mov = this.GetComponent<Movable>();
      
        //InvokeRepeating("leaveTrail", 0 ,0.5f);
    }
    public void leaveTrail()
    {
        
        if (Time.time >= (_nextDot)) {
            
            _nextDot = Time.time + 1/ (density*_mov.velocity.magnitude);
            if (_pos != Vector3.zero)
            {
                
                _trail.Add(Instantiate(dotPrefab1, _pos, Quaternion.identity) as GameObject);
            }
            
            _pos = transform.position;

        }
    }

    void OnCollisionEnter2D()
    {
        TrailMaker.trail.Say(_trail);
        _trailSended = true;

    }
    void OnDestroy()
    {
        if (TouchHandler.applicationIsRunning&(!_trailSended))
        {
            TrailMaker.trail.Say(_trail);
        }
        if (this.gameObject.name == "DemoTrailPoint")
        {
            TrailMaker.transformTrail.Say(_transformTrail);
        }
    }
    
	
	
}
