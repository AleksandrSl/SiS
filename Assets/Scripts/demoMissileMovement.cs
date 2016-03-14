using UnityEngine;
using System.Collections;

class demoMissileMovement : Movable {

    TrailMaker _trailMaker;
    public int _stepNumber = 0; 
    void Awake()
    {
        _trailMaker = GetComponent<TrailMaker>();
        _attr = GetComponent<Attractable>();
    }
    
    void FixedUpdate()

    {
        for (int i = 0; i < 30; ++i)
        {

            this.MovementStep();
            _trailMaker.leaveTrail();
        }

        _stepNumber++;
        if (_stepNumber == 5) 
            Destroy(this.gameObject);
        

    }

    
}
