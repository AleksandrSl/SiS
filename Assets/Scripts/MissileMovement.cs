using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attractable), typeof(TrailMaker), typeof(Rigidbody2D))]
class MissileMovement : Movable {

    private TrailMaker _trailMaker;

    void Awake()
    {
        _trailMaker = GetComponent<TrailMaker>();
        Attr = GetComponent<Attractable>(); // Declared in Movable
    }
	// Update is called once per frame
	void FixedUpdate () {
        MovementStep();
        _trailMaker.LeaveConstTrailByTime();
    }
}
