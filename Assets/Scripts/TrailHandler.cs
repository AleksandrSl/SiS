using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using StateMachine;


public class TrailHandler : MonoBehaviour {

    public float fadeSpeed = 2;
    public int capacity = 3;
    private Queue<List<GameObject>> _trails = new Queue<List<GameObject>>(3);   
    
    void Awake()
    {
        TrailMaker.Trail.Subscribe(addTrail);
    }

    IEnumerator fadeAway(List<GameObject> trail, float fadeLevel = 0.5f)
    {
        float oldAlpha = trail[0].GetComponent<SpriteRenderer>().color.a;
        float finalAlpha = oldAlpha * (1 - fadeLevel);
        float currentTime = 0;
        int duration = 2;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
            foreach (GameObject point in trail)
            {
                SpriteRenderer pRend = point.GetComponent<SpriteRenderer>(); //Maybe it's sensible to create another queue with renderers, because getting the same renderers everytime doesn't seem like a good idea
                pRend.color = new Color(pRend.color.r, pRend.color.g, pRend.color.b, alpha);
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    IEnumerator deleteTrail(List<GameObject> trail)
    {
        float oldAlpha = trail[0].GetComponent<SpriteRenderer>().color.a;
        float finalAlpha = 0.0f;
        float currentTime = 0;
        float duration = 0.5f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
            foreach (GameObject point in trail)
            {
                SpriteRenderer pRend = point.GetComponent<SpriteRenderer>(); //Maybe it's sensible to create another queue with renderers, because getting the same renderers everytime doesn't seem like a good idea
                pRend.color = new Color(pRend.color.r, pRend.color.g, pRend.color.b, alpha);
            }
            currentTime += Time.deltaTime;
            yield return null;
        }
        foreach (GameObject point in trail)
        {
            Destroy(point);
        }
        trail.Clear();
        yield break;
    }


    void addTrail(List<GameObject> trail)
    {
        Debug.Log(trail);
        if (_trails.Count >= capacity)
        {
            StartCoroutine(deleteTrail(_trails.Dequeue()));
           _trails.Enqueue(trail); 
        }
        else
        {
            _trails.Enqueue(trail);
        }
        for (int i = 0; i < (_trails.Count - 1); ++i)
        {
            StartCoroutine(fadeAway(_trails.ElementAt(i), 0.1f));
        }  

    }

    //public List<Vector2> getPath(int pathN)
    //{
    //    List<Vector2> path = new List<Vector2>();
    //    foreach (GameObject point in _trails.ElementAt(pathN))
    //    {
    //        path.Add(point.transform.position);    
    //    }
    //    return path;
    //}    
}
