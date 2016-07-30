using UnityEngine;
using System.Collections;


class Movable: MonoBehaviour
{

    private static float TimeStep = 0.01f;

    protected Attractable Attr;
    private Vector3 _coord = Vector3.zero;


    public Vector2 Velocity { get; set; }

    public Vector2 Acceleration { get; set; }

    protected void MovementStep() // Maybe it's worth to call this function once per two/three updates, and move missile with already calculated velocity during other time. 
    {
        Acceleration = Attr.getGravityField();
        _coord = new Vector3(Velocity.x * TimeStep + (Acceleration.x * (TimeStep * TimeStep) / 2), Velocity.y * TimeStep + (Acceleration.y * (TimeStep * TimeStep) / 2), 0);
        Velocity += Acceleration * TimeStep;
        transform.Translate(_coord);
    }
    protected void MovementStepByInertion()
    {
        _coord = new Vector3(Velocity.x * TimeStep + (Acceleration.x * (TimeStep * TimeStep) / 2), Velocity.y * TimeStep + (Acceleration.y * (TimeStep * TimeStep) / 2), 0); ;
        transform.Translate(_coord);
    }


}
