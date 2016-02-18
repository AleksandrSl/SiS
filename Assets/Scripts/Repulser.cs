using UnityEngine;
using System.Collections;
using System;

class Repulser : GravityElement {
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public override Vector2 getPosition()
    {
        return rb2d.position;
    }
    public override float getMass()
    {
        return rb2d.mass;
    }
    public override void accept(IVisitor visitor)
    {
        visitor.visitElement(this);
    }

}
