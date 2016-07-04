using UnityEngine;
using System.Collections;


public class DemoMissileController : MonoBehaviour {
    /// <summary>
    /// Spawns and destroys demoDots, that make expected flypath
    /// </summary>
    public Rigidbody2D DemoMissile;
    private GameObject prevDemoMissile;
    /// <summary>
    /// destoy all existing demoDots and spawn new demoDot when the message OnDemoFire received
    /// </summary>
    /// <param name="shotForce"></param>
    public void OnDemoFire(float shotForce)
    {
        prevDemoMissile = GameObject.FindGameObjectWithTag("DemoMissile");
        if (prevDemoMissile)
        {
            Destroy(GameObject.FindGameObjectWithTag("DemoMissile")); //Destroy prev missile when a new one is spawned
        }
        Rigidbody2D demoMissileInst = Instantiate(DemoMissile, transform.position, new Quaternion(0, 0, 0, 1)) as Rigidbody2D;
        demoMissileInst.GetComponent<Movable>().Velocity = transform.up * shotForce;
    }
    void Awake()
    {
        Controller.DemoFire.Subscribe(OnDemoFire);
    }
}
