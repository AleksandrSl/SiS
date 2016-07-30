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

    void Awake()
    {
        _objPos = transform.position;
        _stateChanger = GetComponent<StateChanger>();
    }


    void LateUpdate () {

        switch (_caseSwitch)
        {
            case 1:
                if (Input.GetMouseButtonDown(0))
                {
                    _curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _isTargetingStarted = Vector2.Distance(_curPos, _objPos) < StartRadius;
                }
                
                if (_isTargetingStarted)
                {
                    _caseSwitch = 2;
                    _isTargetingStarted = false;
                    Debug.Log("Case switched to 2");
                }
                break;
            case 2:
                if (Input.GetMouseButton(0))
                {
                    _touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (_touchPos == _curPos) return;
                    _curPos = _touchPos;
                    _shotForce = Mathf.Min((Vector2.Distance(_touchPos, transform.position) * 2 - ShotForceMin), ShotForceMax);
                    if (_shotForce < ShotForceMin)
                    {
                        Controller.DestroyDemoFire.Say();
                        return;
                    }
                    Controller.DemoFireForce.Say(_shotForce);
                    Controller.FillRadialElement.Say((_shotForce - ShotForceMin) / (ShotForceMax - ShotForceMin));
                }
                if (Input.GetMouseButtonUp(0))
                {
                    _shotForce = Mathf.Min((Vector2.Distance(_touchPos, transform.position) * 2 - ShotForceMin), ShotForceMax);
                    if (_shotForce < ShotForceMin) return;
                    
                    _caseSwitch = 1;
                    _stateChanger.ChangeState();
                    Controller.DemoFireForce.Say(_shotForce);
                    Controller.FireForce.Say(_shotForce);
                }
                break;
                
        }

        
        
    }
}
