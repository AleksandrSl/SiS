using UnityEngine;
[RequireComponent(typeof(StateChanger))]
public class OnMissilleCollision : MonoBehaviour {
    public ExplosionSpawn ExplosionSpawn;
    private StateChanger _stateChanger;
    void Awake()
    {
        _stateChanger = GetComponent<StateChanger>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet")
        {
            ExplosionSpawn.spawnExplosion(collision.contacts[0].point);
            Destroy(this.gameObject);
            _stateChanger.ChangeState();
        }
        if (collision.collider.tag == "Aim")
        {
            Destroy(this.gameObject);
        }   
    }

}
