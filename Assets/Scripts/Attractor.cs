using UnityEngine;
using System.Collections;
using System;

class Attractor : GravityElement{
    private Rigidbody2D _rb2d;
    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
     
    public override Vector2 getPosition()
    {
        return _rb2d.position;
    }
    public override float getMass()
    {
        return _rb2d.mass;
    }

    public override void accept(IVisitor visitor)
    {
        visitor.visitElement(this);
    }
    


}
