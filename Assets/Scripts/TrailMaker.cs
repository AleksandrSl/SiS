using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrailMaker : MonoBehaviour {
    public static SingleMessage<List<GameObject>> trail = new SingleMessage<List<GameObject>>();
    List<GameObject> _trail = new List<GameObject>();
    
    
    public float density;
    public GameObject dotPrefab1;
    public GameObject dotPrefab2;
    public float firstDot;
    float _nextDot;
    Vector3 _pos = Vector3.zero;
   
    Rigidbody2D _rb2d;
    int _counter;
   
	void Awake()
    {
        _nextDot = firstDot;
        _rb2d = this.GetComponent<Rigidbody2D>();
      
        //InvokeRepeating("leaveTrail", 0 ,0.5f);
    }
    void leaveTrail()
    {
        
        if (Time.time >= (_nextDot)) {
            
            _nextDot = Time.time + 1/ (density*_rb2d.velocity.magnitude);
            if (_pos != Vector3.zero)
            {
                
                _trail.Add(Instantiate(dotPrefab1, _pos, Quaternion.identity) as GameObject);
            }
            
            _pos = transform.position;

        }
    }
    
    void FixedUpdate()
    {
        leaveTrail();
    }
    public void OnDestroy()
    {
        TrailMaker.trail.Say(_trail);
    }
	
	
}
