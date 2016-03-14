using UnityEngine;
using System.Collections;
using System;

class Attractor : GravityElement{
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Debug.Log("Fuck this fucking shit");
        Debug.Log(transform.rotation.ToString());
    }
    public override Vector2 getPosition() {
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
