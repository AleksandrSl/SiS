using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShotForceEvaluator : MonoBehaviour {

    public float startRadius;
    public float shotForceMax;

    private Vector2 _pos2D;
    private Vector2 _startPos;
    private Vector2 _touchPos;
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
            
            if ((Vector2.SqrMagnitude(_startPos - _pos2D)) > startRadius)
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
                _shotForce = Mathf.Min(Vector2.Distance(_touchPos, _startPos)*2, shotForceMax);
                Controller.demoFire.Say(_shotForce);
                Controller.fillRadialElement.Say(_shotForce/shotForceMax);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isStarted = false;
                Controller.Fire.Say(_shotForce);
            }
        }

    }
}
