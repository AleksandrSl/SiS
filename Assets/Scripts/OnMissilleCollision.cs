using UnityEngine;

public class OnMissilleCollision : MonoBehaviour {
    public ExplosionSpawn explosionSpawn;
    public StateChanger stateChanger;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet")
        {
            explosionSpawn.spawnExplosion(collision.contacts[0].point);
            Destroy(this.gameObject);
        }
        if (collision.collider.tag == "Aim")
        {
            
            Destroy(this.gameObject);
            stateChanger.ChangeState(); //Вызывается именно здесь, так как в противном случае стэйт меняется до сохранения пути
        }
        
    }
    
	void Update () {
	
	}

}
