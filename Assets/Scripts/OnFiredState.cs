using UnityEngine;
using System.Collections;

public class OnFiredState : MonoBehaviour {
    public GameObject[] GameObjects;

    public void DisableScripts()
    {
        foreach (var go in GameObjects)
        {
            go.SetActive(false);    
        }     
    }

    public void EnableScripts()
    {
        foreach (var go in GameObjects)
        {
            go.SetActive(true);
        }
    }

}
