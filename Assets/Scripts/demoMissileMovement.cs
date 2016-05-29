using UnityEngine;

namespace Assets.Scripts
{
    class DemoMissileMovement : Movable {

        private TrailMaker _trailMaker;
        private int _stepNumber = 0; 
        void Awake()
        {
            Method = typeof(Movable).Assembly.GetType(ClassName).GetMethod(MethodName);
            Debug.Log(Method);
            Debug.Log(MethodName + "!!!!!!!!!");
            _trailMaker = GetComponent<TrailMaker>();
            Attr = GetComponent<Attractable>();
        }

        void OnEnable()
        {
            
        }

    
        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collide1!!!!!1111!");
            this.enabled = false;
        }
        void FixedUpdate()
        {
            if (_stepNumber < 5)
            {
                for (int i = 0; i < 20; ++i)
                {
                    MovementStep();
//                  _trailMaker.LeaveConstTrailByCoord();
                }
            }
            else
            {
            
                this.enabled = false;
            }
            _stepNumber++;
        }
    }
}
