using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(StateChanger))]
public class ShotForceEvaluator : MonoBehaviour {

    public float StartRadius;
    public static float ShotForceMax = 100.0f;
    public float ShotForceMin = 20.0f;

    private Vector2 _objPos;
    private Vector2 _touchPos;
    private Vector2 _curPos;
    private float _shotForce;
    private bool _isTargetingStarted = false;
    private StateChanger _stateChanger;
    private int _caseSwitch = 1;
    private bool _isReadyForShot = false;

    void Awake()
    {
        _objPos = transform.position;
        _stateChanger = GetComponent<StateChanger>();
    }


    void LateUpdate () {

        if (Input.GetMouseButtonDown(0))
        {
            _curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isTargetingStarted = Vector2.Distance(_curPos, _objPos) < StartRadius;
        }
                
        if (!_isTargetingStarted)
        {
            return;
        }
         
        if (Input.GetMouseButton(0))
        {
            _touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_touchPos == _curPos)
            {
                return;
            }
            _curPos = _touchPos;
            _shotForce = Mathf.Min((Vector2.Distance(_touchPos, transform.position) * 2 - ShotForceMin), ShotForceMax);
            if (_shotForce < ShotForceMin)
            {
                Controller.DestroyDemoFire.Say();
                return; //Можно _isTargetingStarted сделать false, но тогда придется заново щелкать в центр корабля. Наверное не очень удобно
            }   
            Controller.DemoFireForce.Say(_shotForce);
            Controller.FillRadialElement.Say((_shotForce - ShotForceMin) / (ShotForceMax - ShotForceMin));
            _isReadyForShot = true;
        }
                
        if (!_isReadyForShot)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _shotForce = Mathf.Min((Vector2.Distance(_touchPos, transform.position) * 2 - ShotForceMin), ShotForceMax);
            if (_shotForce < ShotForceMin)
            {
                return;
            }
            _stateChanger.ChangeState();
            Controller.DemoFireForce.Say(_shotForce);
            Controller.FireForce.Say(_shotForce);
            Controller.DestroyDemoFire.Say();
        }
        
    }
}
