using UnityEngine;
using System.Collections;


class Movable: MonoBehaviour
{
    protected Attractable _attr;
    public float timeStep;

    private Vector3 _coord = Vector3.zero;
    private Vector2 _velocity;
    private Vector2 _acceleration;


    public Vector2 velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = value;
        }
    }
    public Vector2 acceleration
    {
        get
        {
            return _acceleration;
        }
        set
        {
            _acceleration = value;
        }
    }

    protected void MovementStep()
    {

        acceleration = _attr.getGravityField();
        velocity += acceleration * timeStep;
        Vector3 _coord = new Vector3(velocity.x * timeStep, velocity.y * timeStep, 0);
        transform.Translate(_coord);

    }



}
