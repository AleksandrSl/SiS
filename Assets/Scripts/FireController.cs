using UnityEngine;
using System.Collections;


public class FireController : MonoBehaviour {
	public Rigidbody2D Missile;
    
    public void OnFire(float shotForce){
		Rigidbody2D missileInst = Instantiate(Missile, transform.position, new Quaternion(0, 0, 0, 1 )) as Rigidbody2D;
        missileInst.GetComponent<Movable>().Velocity = transform.up * shotForce;
        Debug.Log("Real vel: " + missileInst.GetComponent<Movable>().Velocity);
        Debug.Log("Real trans: " + transform.up);
    }
	void Awake(){
		Controller.Fire.Subscribe (OnFire);
	}
}
