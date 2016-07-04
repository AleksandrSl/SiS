using UnityEngine;
using System.Collections;

class DemoMissileMovement : Movable {

    private TrailMaker _trailMaker;
    private int _stepNumber = 0; 
    void Awake()
    {
        _trailMaker = GetComponent<TrailMaker>();
        Attr = GetComponent<Attractable>();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Attr.enabled = false;
    }
    void FixedUpdate()
    {
        for (int i = 0; i < 50; ++i)
        {
            this.MovementStep();
            _trailMaker.LeaveConstTrailByCoord();
        }
        enabled = false;
        //Destroy(this.gameObject); //Destroy missile when it has reached the end of its path
    }
}
