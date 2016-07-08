using UnityEngine;

public class OnMissilleCollision : MonoBehaviour {
    public ExplosionSpawn ExplosionSpawn;
    public StateChanger StateChanger;
    public TrailMaker TrailMaker;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //TrailMaker.SendTrail();

        if (collision.collider.tag == "Planet")
        {
            ExplosionSpawn.spawnExplosion(collision.contacts[0].point);
            Destroy(this.gameObject);
        }
        if (collision.collider.tag == "Aim")
        {
            
            Destroy(this.gameObject);
            StateChanger.ChangeState(); //Вызывается именно здесь, так как в противном случае стэйт меняется до сохранения пути
        }
        
    }
    
	void Update () {
	
	}

}
