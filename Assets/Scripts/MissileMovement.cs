using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attractable), typeof(TrailMaker), typeof(Rigidbody2D))]
class MissileMovement : Movable {

    private int _stepNum;
    private TrailMaker _trailMaker;

    void Awake()
    {
        _stepNum = 0;
        _trailMaker = GetComponent<TrailMaker>();
        Attr = GetComponent<Attractable>(); // Declared in Movable
    }
    //void FixedUpdate () {
    //       if (_stepNum == 0)
    //       {
    //           MovementStep();
    //       }
    //       else
    //       {
    //           MovementStepByInertion();
    //       }
    //       Debug.Log(_stepNum);
    //       _stepNum = (_stepNum + 1) % 2;
    //       _trailMaker.LeaveConstTrailByTime();
    //   }


    void FixedUpdate()
    {
        MovementStep();
        _trailMaker.LeaveConstTrailByTime();
    }
}
