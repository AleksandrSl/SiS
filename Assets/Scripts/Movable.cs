using UnityEngine;
using System.Collections;


class Movable: MonoBehaviour
{

    private static float TimeStep = 0.01f;

    protected Attractable Attr;
    private Vector3 _coord = Vector3.zero;


    public Vector2 Velocity { get; set; }

    public Vector2 Acceleration { get; set; }

    protected void MovementStep()
    {
        Acceleration = Attr.getGravityField();
        Velocity += Acceleration * TimeStep;
        _coord = new Vector3(Velocity.x * TimeStep, Velocity.y * TimeStep, 0);
        transform.Translate(_coord);
    }



}
