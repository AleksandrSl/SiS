using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Camera Cam;
    [SerializeField]
    AnimationCurve DamperCurve;
    private float _damperTime;
    public float Magnitude;
    // Use this for initialization
    void Awake()
    {
        Cam = GetComponent<Camera>();
        Controller.ExplSpawned.Subscribe(StartShake);
    }
    IEnumerator Shake(float shakeDuration)
    {
        Vector3 originalCamPos = transform.position;
        while (_damperTime < shakeDuration)
        {
            float damper = DamperCurve.Evaluate(_damperTime);
            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= Magnitude * damper;
            y *= Magnitude * damper;
            //Debug.Log("Shake started");

            transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);
            _damperTime += Time.deltaTime;
            yield return null;
        }
       
    }

    private void StartShake(float shakeDuration)
    {
        _damperTime = 0;
        StartCoroutine(Shake(shakeDuration));
    }
}
