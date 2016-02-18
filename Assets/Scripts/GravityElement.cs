using UnityEngine;
using System.Collections;

abstract class GravityElement : Element {
    // Rigidbody2D rb2d;
    //void Awake()
    //{
    //    rb2d = GetComponent<Rigidbody2D>();
    //}
    public abstract float getMass();
    //{
    //    return rb2d.mass;
    //}
    public abstract Vector2 getPosition();
    //{
    //    return rb2d.position;
    //}
}
