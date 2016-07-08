using UnityEngine;
using System.Collections;

public class OnDemoMissileCollision : MonoBehaviour
{
    public TrailMaker TrailMaker;
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        TrailMaker.ChangeTrailColor(Color.white);
    }
}