using UnityEngine;
using System.Collections;

public class OnAimCollision : MonoBehaviour {
    StateChanger _stateChanger;
    Vector2 _pos;
    public GameObject teleportPrafeb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        Destroy(collision.gameObject);
        _pos = transform.position;
        Destroy(this.gameObject);
        GameObject teleport = Instantiate(teleportPrafeb, _pos, Quaternion.identity) as GameObject;
        Animator explosionAnim = teleport.GetComponent<Animator>();
        DestroyObject(teleport, explosionAnim.GetCurrentAnimatorStateInfo(0).length);
        _stateChanger.ChangeState();

    }
    void Awake() {
        _stateChanger = GetComponent<StateChanger>();
    }
   
    
    void OnDestroy() {
        
       
        
        
    }
	// Update is called once per frame
	
}
