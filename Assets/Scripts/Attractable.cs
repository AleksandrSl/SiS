using UnityEngine;
using System.Collections;
using System;


class Attractable : MonoBehaviour, IVisitor {

    private Rigidbody2D _rb2d;
    private Movable _movement;
    private Element[] _elements;
    private Vector2 _gravityField;
   
    public void visitElement(Attractor attractor)
    {  
        _gravityField += CalculateForce(attractor.getMass(), attractor.getPosition()); // Прибавить силу действующую со стороны Attractor
    }

    public void visitElement(Repulser repulser)
    {
        _gravityField -= CalculateForce(repulser.getMass(), repulser.getPosition()); // Вычесть силу действующую со стороны Repulser
    }

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movable>();
        _elements = FindObjectsOfType(typeof(Element)) as Element[];
    }
    
    
    public Vector2 CalculateForce(float attractorMass, Vector2 attractorPosition)
    {
        float angle;
        float dist = Vector2.Distance(attractorPosition, transform.position);
        Vector2 forceVect = attractorPosition - (Vector2)transform.position;
        if (attractorPosition.x < transform.position.x)
        {  // Так как угол определяемый Vector2.Angle() у меня получался от 0 до 180
            angle = (360 - (Vector2.Angle(forceVect, Vector2.up))) * Mathf.PI / 180.0f;
        }
        else
        {
            angle = (Vector2.Angle(forceVect, Vector2.up)) * Mathf.PI / 180.0f;
        }
        float gravityFieldValue = (float)System.Math.Round((attractorMass) / (dist * dist), 1);

        return new Vector2((gravityFieldValue * Mathf.Sin(angle)), (gravityFieldValue * Mathf.Cos(angle)));
    }


    public Vector2 GetGravityField()
    {
        _gravityField = Vector2.zero;
        foreach (Element el in _elements)   //я не очень представляю, как правильно сложить силы, если это дело реализовать как положено в element, то каждый объект element будет по отдельности по очереди тянуть)
        {
            el.accept(this);
        }
        return _gravityField;
    }
}
