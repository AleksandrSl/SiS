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
    public GameObject DotPrefab1;
    public GameObject DotPrefab2;
    public float FirstDot;
    private float _nextDotTime;
   
    private float _completedPath;
    private float _traversedDist;
    
    private Vector2 _curPos;
    private Vector2 _prevPos;
    private float _startVel;
    private float _maxVel;
    private bool _trailSended = false;
    private Movable _mov;
    private int _counter;
    private float _nextDotDist;

    void Awake()
    {
        _nextDotTime = FirstDot;
	    _curPos = transform.position;
        _nextDotDist = 1/Density;
	    _traversedDist = 0;
        _mov = this.GetComponent<Movable>();
        _maxVel = ShotForceEvaluator.ShotForceMax;
    }
    void Start()
    {
        _startVel = _mov.Velocity.magnitude;
    }
    public void LeaveConstTrailByTime()
    {
        _curPos = transform.position;
        if (Time.time < _nextDotTime) return;
        _nextDotTime += 1/(Density * _mov.Velocity.magnitude);
        _trail.Add(Instantiate(DotPrefab1, _curPos, Quaternion.identity) as GameObject);
    }

    public void LeaveConstTrailByCoord()
    {
        _prevPos = _curPos;
        _curPos = transform.position;
        _traversedDist += Vector2.Distance(_curPos, _prevPos);
        if (_traversedDist < _nextDotDist) return;
        _nextDotDist += 1/ (Density * ((_startVel / _maxVel)));
        _trail.Add(Instantiate(DotPrefab1, _curPos, Quaternion.identity) as GameObject);
        
    }

    void OnCollisionEnter2D()
    {
        if (gameObject.tag == "DemoMissile")
        {
            foreach (var dot in _trail)
            {
                SpriteRenderer sprRend = dot.GetComponent<SpriteRenderer>();
                sprRend.color = Color.blue;
                //Destroy(dot);
            }
            Debug.Log("Destroyed!!");
            return;
        }
        else
        {
            TrailMaker.Trail.Say(_trail);
            _trailSended = true;
        }
    }
    void OnDestroy()
    {
        if (gameObject.tag == "DemoMissile")
        {
            foreach (var dot  in _trail)
            {
                Destroy(dot);
            }
            Debug.Log("Destroyed!!");
            return;
        }
        if (TouchHandler.applicationIsRunning&(!_trailSended))
        {
            Debug.Log("Sended");
            TrailMaker.Trail.Say(_trail);
            
        }
    }
}
