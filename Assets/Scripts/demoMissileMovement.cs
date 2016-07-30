using UnityEngine;
using System.Collections;

class DemoMissileMovement : Movable {

    private TrailMaker _trailMaker;
 
    void Awake()
    {
        _trailMaker = GetComponent<TrailMaker>();
        Attr = GetComponent<Attractable>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected"); //Collision detected only after the path is rendered, thus the path lies through planets
        enabled = false;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < 40; ++i)
        {
            this.MovementStep();
            _trailMaker.LeaveSteadyTrail();
        }
        enabled = false;
    }
}
