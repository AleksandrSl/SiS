using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShotForceEvaluator : MonoBehaviour {

    public float StartRadius;
    public float ShotForceMax;

    private Vector2 _objPos;
    private Vector2 _startPos;
    private Vector2 _touchPos;
    private Vector2 _curPos;
    private float _shotForce;
    private bool _isStarted = false;

    void Awake()
    {
        _objPos = transform.position;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("MouseButtonPressed");
            _startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _curPos = _startPos;
            _isStarted = (Vector2.SqrMagnitude(_startPos - _objPos)) > StartRadius;
        }

        if (!_isStarted) return;

        if (Input.GetMouseButton(0))
        {
            _touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_touchPos == _curPos) return;
            _curPos = _touchPos;
            _shotForce = Mathf.Min(Vector2.Distance(_touchPos, _startPos)*2, ShotForceMax);
            Controller.DemoFire.Say(_shotForce);
            Controller.FillRadialElement.Say(_shotForce/ShotForceMax);
            //Debug.Log("Demo: " + _shotForce);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isStarted = false;
            Controller.Fire.Say(_shotForce);
            //Debug.Log("Real: " + _shotForce);
        }
    }
}
