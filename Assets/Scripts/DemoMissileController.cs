﻿using UnityEngine;
using System.Collections;


public class DemoMissileController : MonoBehaviour {
    /// <summary>
    /// Spawns and destroys demo<issiles, that make expected flypath
    /// </summary>
    public Rigidbody2D DemoMissile;
    private GameObject _prevDemoMissile;
    /// <summary>
    /// destoy all existing demoMissiles and spawn new demoMissile when the message OnDemoFire received
    /// </summary>
    /// <param name="shotForce"></param>
    public void OnDemoFire(float shotForce)
    {
        _prevDemoMissile = GameObject.FindGameObjectWithTag("DemoMissile");
        if (_prevDemoMissile)
        {
            Destroy(_prevDemoMissile); //Destroy prev missile when a new one is spawned
        }
        Rigidbody2D demoMissileInst = Instantiate(DemoMissile, transform.position, new Quaternion(0, 0, 0, 1)) as Rigidbody2D;
        demoMissileInst.GetComponent<Movable>().Velocity = transform.up * shotForce;
    }

    private void DestroyOnRealFire(float shotForce)
    {
        Debug.Log("Destroy demoMissile");
        Destroy(GameObject.FindGameObjectWithTag("DemoMissile"));
    }

    private void DestroyWithoutDelay()
    {
        Destroy(GameObject.FindGameObjectWithTag("DemoMissile"));
    }


    void Awake()
    {
        Controller.DemoFireForce.Subscribe(OnDemoFire);
        Controller.FireForce.Subscribe(DestroyOnRealFire);
        Controller.DestroyDemoFire.Subscribe(DestroyWithoutDelay);
    }
}
