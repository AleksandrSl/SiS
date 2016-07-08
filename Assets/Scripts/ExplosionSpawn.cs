using UnityEngine;
using System.Collections;

public class ExplosionSpawn:MonoBehaviour {
    public GameObject explosionPrefab;
	
    public void spawnExplosion(Vector2 collisionPoint)
    {
        GameObject explosion = Instantiate(explosionPrefab, collisionPoint, Quaternion.identity) as GameObject;
        Animator explosionAnim = explosion.GetComponent<Animator>();
        Controller.ExplSpawned.Say(explosionAnim.GetCurrentAnimatorStateInfo(0).length);
        DestroyObject(explosion, explosionAnim.GetCurrentAnimatorStateInfo(0).length);
    }
	
	
}
