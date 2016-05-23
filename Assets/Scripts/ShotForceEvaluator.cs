using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShotForceEvaluator : MonoBehaviour {

    public float StartRadius;
    public float ShotForceMax;

    private Vector2 _pos2D;
    private Vector2 _startPos;
    private Vector2 _touchPos;
    private Vector2 _curPos;
    private float _shotForce;
    private bool _isStarted = false;

    void Awake()
    {
        _pos2D = new Vector2(transform.position.x, transform.position.y);
        //Controller.Touch.Subscribe(OnRotationCommand);
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _curPos = _startPos;
            if (!((Vector2.SqrMagnitude(_startPos - _pos2D)) > StartRadius))
            {
                _isStarted = false;
            }
            else
            {
                _isStarted = true;
            }
        }

        if (_isStarted)
        {
            
            if (Input.GetMouseButton(0))
            {
                
                _touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (_touchPos != _curPos)
                {
                    _curPos = _touchPos;
                    _shotForce = Mathf.Min(Vector2.Distance(_touchPos, _startPos)*2, ShotForceMax);
                    Controller.demoMissileDestroy.Say();
                    Controller.demoFire.Say(_shotForce);
                    Debug.Log(_shotForce/ShotForceMax);
                    Controller.fillRadialElement.Say(_shotForce/ShotForceMax);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isStarted = false;
                Controller.Fire.Say(_shotForce);
            }
        }

    }
}
