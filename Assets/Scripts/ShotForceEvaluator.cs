using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShotForceEvaluator : MonoBehaviour {

    public float StartRadius;
    public static float ShotForceMax = 100;

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

    void LateUpdate () {
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
            _shotForce = Mathf.Min(Vector2.Distance(_touchPos, transform.position)*2, ShotForceMax);
            Controller.DemoFire.Say(_shotForce);
            Controller.FillRadialElement.Say(_shotForce/ShotForceMax);
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isStarted = false;
            Controller.DemoFire.Say(_shotForce);
            Controller.Fire.Say(_shotForce);
        }
    }
}
