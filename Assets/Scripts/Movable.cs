using UnityEngine;

using System.Collections;


class Movable: MonoBehaviour
{

    private static float _timeStep = Time.fixedDeltaTime;
    protected Attractable Attr;
    private Vector2 _coord = Vector2.zero;


    public Vector2 Velocity { get; set; }

    public Vector2 Acceleration { get; set; }

    protected void MovementStep() // Maybe it's worth to call this function once per two/three updates, and move missile with already calculated velocity during other time. 
    {
        
        Acceleration = Attr.GetGravityField();
        _coord = new Vector2(Velocity.x * _timeStep + (Acceleration.x * (_timeStep * _timeStep) / 2), Velocity.y * _timeStep + (Acceleration.y * (_timeStep * _timeStep) / 2));
        //Debug.Log(_coord);
        Velocity += Acceleration * _timeStep;
        if (_coord == Vector2.zero)
        {
            return;
        }
        transform.Translate(_coord);
    }
    //protected void MovementStepByInertion()
    //{
    //    _coord = new Vector3(Velocity.x * TimeStep + (Acceleration.x * (TimeStep * TimeStep) / 2), Velocity.y * TimeStep + (Acceleration.y * (TimeStep * TimeStep) / 2), 0); ;
    //    transform.Translate(_coord);
    //}


}
