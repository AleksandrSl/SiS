using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    AnimationCurve DamperCurve;
    public float _damperTime;
    public float magnitude;
    // Use this for initialization
    void Awake()
    {
        cam = GetComponent<Camera>();
    }
    void Start()
    {

    }
    IEnumerator Shake()
    {
        Vector3 originalCamPos = transform.position;
        
        while (GameObject.FindGameObjectWithTag("Explosion"))
        {
            float damper = DamperCurve.Evaluate(_damperTime);
            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;
            //Debug.Log("Shake started");

            transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return null;
        }
    }
    //    void Shake()
    //{
    //   transform.position += new Vector3()
    //}
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Explosion"))
        {

            //Debug.Log("Expl");
            //print(transform.position.x);
            _damperTime = 0;
            _damperTime += Time.deltaTime;
            _damperTime *= 10;
            StartCoroutine(Shake());
        }
    }
}
