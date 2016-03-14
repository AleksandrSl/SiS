using UnityEngine;
using System.Collections;


public class FireController : MonoBehaviour {
	public Rigidbody2D missile;
    public Rigidbody2D demoMissile;
    
    
    public void OnFire(float shotForce){
		Rigidbody2D missileCopy = Instantiate(missile, transform.position, new Quaternion(0, 0, 0, 1 )) as Rigidbody2D;
        //Debug.Log(transform.up.normalized);
        missileCopy.GetComponent<MissileMovement>().velocity = transform.up *shotForce; 
        
        
        
	}

    public void OnDemoFire(float shotForce)
    {
        Rigidbody2D demoMissileCopy = Instantiate(demoMissile, transform.position, new Quaternion(0, 0, 0, 1)) as Rigidbody2D;
        Debug.Log("DemoFire");
        demoMissileCopy.GetComponent<Movable>().velocity = transform.up * shotForce;
    }
	void Awake(){
		Controller.Fire.Subscribe (OnFire);
        Controller.demoFire.Subscribe(OnDemoFire);
	}
}
