using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class TrailMaker : MonoBehaviour {
    public static SingleMessage<List<GameObject>> Trail = new SingleMessage<List<GameObject>>();
    public static SingleMessage<List<Vector2>> TransformTrail = new SingleMessage<List<Vector2>>();
    private List<GameObject> _trail = new List<GameObject>();
    

    public float Density = 2.5f;
    public GameObject DotPrefab1;
    public GameObject DotPrefab2;
    public float FirstDot;
    public int WhereTrailBegins = 1;
   
   
    private float _completedPath;
    private float _traversedDist;
    
    private Vector2 _curPos;
    private Vector2 _prevPos;
    private bool _trailSended = false;
    private int _dotNum;
    private float _distToNextDot;

    void Awake()
    {
        _curPos = transform.position;
	    _traversedDist = 0;
        _distToNextDot = Density * _dotNum;
        _dotNum = WhereTrailBegins;
    }

    //public void LeaveConstTrailByTime()
    //{
    //    _curPos = transform.position;
    //    if (Time.time < _nextDotTime) return;
    //    _nextDotTime += 1/(Density * _mov.Velocity.magnitude);
    //    Debug.Log((1 / (Density * _mov.Velocity.magnitude)) * 1000000);
    //    _trail.Add(Instantiate(DotPrefab1, _curPos, Quaternion.identity) as GameObject);
    //}

    public void LeaveConstTrail()
    {
        _prevPos = _curPos;
        _curPos = transform.position;
        _traversedDist += Vector2.Distance(_curPos, _prevPos);
        
        while (((_curPos - _prevPos).normalized * _distToNextDot).magnitude < _traversedDist)
        {
            _distToNextDot = Density * _dotNum;
            _trail.Add(Instantiate(DotPrefab1, (_curPos - _prevPos).normalized * (_distToNextDot - _traversedDist) + _prevPos, Quaternion.identity) as GameObject);
            _dotNum++;
        }
    }

    public void DestroyTrail()
    {
        foreach (var dot in _trail)
        {
            Destroy(dot);
        }
    }

    public void ChangeTrailColor(Color color)
    {
        foreach (var dot in _trail)
        {
            SpriteRenderer sprRend = dot.GetComponent<SpriteRenderer>();
            sprRend.color = color;
        }
    }

    public void SendTrail()
    {
        TrailMaker.Trail.Say(_trail);
    }

    void OnDestroy()
    {
        if (gameObject.tag == "DemoMissile")
        {
            DestroyTrail();
        }
        else if (TouchHandler.applicationIsRunning&(!_trailSended))
        {
            SendTrail();  
        }
    }
}
