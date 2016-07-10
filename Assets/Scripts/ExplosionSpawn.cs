using UnityEngine;
using System.Collections;

public class ExplosionSpawn:MonoBehaviour {
    public GameObject explPrefab;
    public AudioClip explSound;
	
    public void spawnExplosion(Vector2 collisionPoint)
    {
        SoundManager.instance.PlaySingle(explSound);
        GameObject explosion = Instantiate(explPrefab, collisionPoint, Quaternion.identity) as GameObject;
        Animator explosionAnim = explosion.GetComponent<Animator>();
        Controller.ExplSpawned.Say(explosionAnim.GetCurrentAnimatorStateInfo(0).length);
        DestroyObject(explosion, explosionAnim.GetCurrentAnimatorStateInfo(0).length);
    }
	
	
}
