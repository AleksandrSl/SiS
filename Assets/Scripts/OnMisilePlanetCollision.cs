using UnityEngine;

public class OnMisilePlanetCollision : MonoBehaviour {
    public ExplosionSpawn explosionSpawn;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        explosionSpawn.spawnExplosion(collision.contacts[0].point);
        Destroy(collision.gameObject);
        
    }
    
	void Update () {
	
	}
}
