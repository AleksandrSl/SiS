using UnityEngine;
using System.Collections;
using Assets.Scripts;


[RequireComponent(typeof(Attractable), typeof(TrailMaker), typeof(Rigidbody2D))]
public class MissileMovement : Movable {

    private TrailMaker _trailMaker;

    void Awake()
    {
        Method = typeof(Movable).Assembly.GetType(ClassName).GetMethod(MethodName);
        _trailMaker = GetComponent<TrailMaker>();
        Attr = GetComponent<Attractable>(); // Declared in Movable
    }
	// Update is called once per frame
	void FixedUpdate () {
        MovementStep(Method);
        //_trailMaker.LeaveConstTrailByTime();
    }
}
