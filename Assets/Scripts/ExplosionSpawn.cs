using UnityEngine;
using System.Collections;

public class ExplosionSpawn:MonoBehaviour {
    public GameObject explosionPrefab;
    // Use this for initialization
    
	
    public void spawnExplosion(Vector2 collisionPoint)
    {
        GameObject explosion = Instantiate(explosionPrefab, collisionPoint, Quaternion.identity) as GameObject;
        Animator explosionAnim = explosion.GetComponent<Animator>();
        DestroyObject(explosion, explosionAnim.GetCurrentAnimatorStateInfo(0).length);
       

    }
	// Update is called once per frame
	
}
