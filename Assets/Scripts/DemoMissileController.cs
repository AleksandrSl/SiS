using UnityEngine;
using System.Collections;


public class DemoMissileController : MonoBehaviour {
    /// <summary>
    /// Spawns and destroys demoDots, that make expected flypath
    /// </summary>
    public Rigidbody2D DemoMissile;
    
    private int _counter;

    /// <summary>
    /// destoy all existing demoDots and spawn new demoDot when the message OnDemoFire received
    /// </summary>
    /// <param name="shotForce"></param>
    public void OnDemoFire(float shotForce)
    {
        if (_counter > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("DemoMissile"));
            _counter -= 1;
        }
        Rigidbody2D demoMissileInst = Instantiate(DemoMissile, transform.position, new Quaternion(0, 0, 0, 1)) as Rigidbody2D;
        demoMissileInst.GetComponent<Movable>().Velocity = transform.up * shotForce;
        Debug.Log("Demo vel: " + demoMissileInst.GetComponent<Movable>().Velocity);
        Debug.Log("Demo trans: " + transform.up);
        _counter += 1;
    }
    void Awake()
    {
        _counter = 0;
        Controller.DemoFire.Subscribe(OnDemoFire);
    }
}
