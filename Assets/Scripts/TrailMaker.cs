using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class TrailMaker : MonoBehaviour {
    public static SingleMessage<List<GameObject>> Trail = new SingleMessage<List<GameObject>>();
    public static SingleMessage<List<Vector2>> TransformTrail = new SingleMessage<List<Vector2>>();
    List<GameObject> _trail = new List<GameObject>();
    List<Vector2> _transformTrail = new List<Vector2>();

    
    public float Density;
    public GameObject dotPrefab1;
    public GameObject dotPrefab2;
    public float firstDot;
    float _nextDotTime;
   
    private float _completedPath;
    private float _traversedDist;
    private Vector2 _curCoord;
    private Vector2 _prevCoord;
    Vector3 _pos = Vector3.zero;

    bool _trailSended = false;
    Movable _mov;
    int _counter;
    private float _nextDotDist;

    void Awake()
    {
        _nextDotTime = firstDot;
	    _curCoord = transform.position;
        _nextDotDist = 1/Density;
        _prevCoord = transform.position;
	    _traversedDist = 0;
        _mov = this.GetComponent<Movable>();
    }
    public void leaveTrail()
    {
        if (!(Time.time >= (_nextDotTime))) return;
        _nextDotTime += 1/(Density*_mov.velocity.magnitude);
            
        if (_pos != Vector3.zero)
        {
                
            _trail.Add(Instantiate(dotPrefab1, _pos, Quaternion.identity) as GameObject);
        }

        _pos = transform.position;
    }

    public void LeaveTrailByCoord()
    {
        _traversedDist += Vector2.Distance(_curCoord, _prevCoord);
        _curCoord = transform.position;
        if (_traversedDist > _nextDotDist)
        {
            _nextDotDist += 1/Density;
            Debug.Log(_nextDotDist);
            _trail.Add(Instantiate(dotPrefab1, transform.position, Quaternion.identity) as GameObject);
        }
    }

    void OnCollisionEnter2D()
    {
        TrailMaker.Trail.Say(_trail);
        _trailSended = true;
    }
    void OnDestroy()
    {
        if (TouchHandler.applicationIsRunning&(!_trailSended))
        {
            TrailMaker.Trail.Say(_trail);
        }
        //if (this.gameObject.name == "DemoTrailPoint")
        //{
        //    TrailMaker.TransformTrail.Say(_transformTrail);
        //}
    }
}
