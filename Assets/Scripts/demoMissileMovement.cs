using UnityEngine;
using System.Collections;

class demoMissileMovement : Movable {

    private TrailMaker _trailMaker;
    public int _stepNumber = 0; 
    void Awake()
    {
        _trailMaker = GetComponent<TrailMaker>();
        _attr = GetComponent<Attractable>();
        Controller.demoMissileDestroy.Subscribe(destroy);
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
    void FixedUpdate()
    {

        for (int i = 0; i < 5; ++i)
        {
            this.MovementStep();
           _trailMaker.LeaveTrailByCoord();
        }

        _stepNumber++;
        if (_stepNumber == 5)
            Destroy(this.gameObject);
    }
}
