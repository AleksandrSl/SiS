using UnityEngine;
using System.Collections;

class MissileMovement : Movable {

    TrailMaker _trailMaker;
    void Awake()
    {
        _trailMaker = GetComponent<TrailMaker>();
        _attr = GetComponent<Attractable>();
    }
	// Update is called once per frame
	void FixedUpdate () {
        this.MovementStep();
        _trailMaker.leaveTrail();

    }
}
