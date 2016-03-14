using UnityEngine;
using UnityEngine.EventSystems;



public class RotationController : MonoBehaviour
{
    
    public float rotationSpeed;
    private Vector2 _direction;

    private Vector2 _pos2D;
    private Vector2 _touchPos;

    //#if UNITY_ANDROID

    //    public bool getAimingStatus()
    //    {
    //        return _isStarted;
    //    }
    //    public void OnRotationCommand(Touch touch) {
    //        if (enabled)
    //        {
    //            //Vector3 coord_3d_ = new Vector3(coord_2d.x, coord_2d.y, 0);

    //            switch (touch.phase)
    //            {
    //                // Record initial touch position.
    //                case TouchPhase.Began:
    //                    _startPos = touch.rawPosition;
    //                    _direction = _startPos - _pos2D;
    //                    //Controller.Fire.Say(200);
    //                    //Debug.Log(Vector2.SqrMagnitude(_startPos - _pos2D));
    //                    if ((Vector2.SqrMagnitude(_startPos - _pos2D)) > startRadius )

    //                    {
    //                        _isStarted = false;
    //                    }
    //                    else
    //                    {
    //                        _isStarted = true;
    //                    }
    //                    break;


    //                // Determine direction by comparing the current touch position with the initial one.
    //                case TouchPhase.Moved:
    //                    if (_isStarted)
    //                    {

    //                        _shotForce = Vector2.Distance(touch.rawPosition, _startPos);
    //                        _direction = touch.rawPosition - _pos2D;
    //                        _shotForce = Mathf.Min(Vector2.Distance(touch.rawPosition, _startPos), shotForceMax);
    //                        // radProgressBar.IncrementValue(1);
    //                        //Debug.Log(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), _startPos));
    //                        //Debug.Log(_shotForce / shotForceMax * 100);
    //                        radProgressBar.SetFillerSizeAsPercentage(_shotForce / shotForceMax * 100);
    //                    }
    //                    break;

    //                // Report that a direction has been chosen when the finger is lifted.
    //                case TouchPhase.Ended:
    //                    if (_isStarted)
    //                    {
    //                        Controller.Fire.Say(_shotForce);
    //                        _direction = touch.rawPosition - _pos2D;
    //                        _isStarted = false;
    //                    }
    //                    break;
    //                }
    //            }
    //                    Quaternion _touchRotation = Quaternion.LookRotation(Vector3.forward, _direction);

    //        if (!EventSystem.current.IsPointerOverGameObject())
    //                    {
    //                        if (_touchRotation != transform.rotation)
    //                        { //Is't worth to do so?

    //                            transform.rotation = Quaternion.Slerp(transform.rotation, _touchRotation, rotationSpeed * Time.deltaTime);
    //                        }
    //                    }

    //                    //Debug.Log("Rotation Started");Ъ
    //            }


    //#endif


    void Awake()
    {
        _pos2D = new Vector2(transform.position.x, transform.position.y);
        //Controller.Touch.Subscribe(OnRotationCommand);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = _touchPos - _pos2D;
            Quaternion _touchRotation = Quaternion.LookRotation(Vector3.forward, _direction);
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (_touchRotation != transform.rotation)
                { //Is't worth to do so?
                    transform.rotation = Quaternion.Slerp(transform.rotation, _touchRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }

    }
}