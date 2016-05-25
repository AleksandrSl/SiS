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
        Debug.Log("Collide1!!!!!1111!");
        Attr.enabled = false;
    }
    void FixedUpdate()
    {
        if (_stepNumber < 10)
        {
            for (int i = 0; i < 5; ++i)
            {
                this.MovementStep();
                _trailMaker.LeaveConstTrailByCoord();
            }
        }
        else
        {
            //Attr.enabled = false;
            this.enabled = false;
        }
        _stepNumber++;
    }
}
