using UnityEngine;
using System.Collections;
using System;


class Attractable : MonoBehaviour, IVisitor { 
    ConstantForce2D constForce;
    Rigidbody2D rb2d;
    
    Element[] elements;

    Vector2 gravityForce;
   
    public void visitElement(Attractor attractor) {
        
        gravityForce += calculateForce(attractor.getMass(), attractor.getPosition()); // Прибавить силу действующую со стороны Attractor
    }
    public void visitElement(Repulser repulser) {
        
        gravityForce -= calculateForce(repulser.getMass(), repulser.getPosition()); // Вычесть силу действующую со стороны Repulser

    }
    void Awake()
    {
        constForce = GetComponent<ConstantForce2D>();
        rb2d = GetComponent<Rigidbody2D>();
        elements = FindObjectsOfType(typeof(Element)) as Element[];
    }

    public Vector2 calculateForce(float attractorMass, Vector2 attractorPosition) {
        float angle;
        float dist = Vector2.Distance(attractorPosition, this.transform.position);
        Vector2 forceVect = attractorPosition - (Vector2)transform.position;
        if (attractorPosition.x < transform.position.x){  // Так как угол определяемый Vector2.Angle() у меня получался от 0 до 180
            angle = (360 - (Vector2.Angle(forceVect, Vector2.up)))*Mathf.PI/180;
        }
        else {
            angle = (Vector2.Angle(forceVect, Vector2.up)) * Mathf.PI / 180.0f;
        }
        float gravityForceValue =(attractorMass*rb2d.mass)/(dist*dist);
        
        return new Vector2((gravityForceValue * Mathf.Sin(angle))/10, (gravityForceValue * Mathf.Cos(angle))/10);
        
        
        }


    void FixedUpdate() {


        gravityForce = Vector2.zero;
        foreach (Element el in elements)   //я не очень представляю, как правильно сложить силы, если это дело реализовать как положено в element, то каждый объект element будет по отдельности по очереди тянуть)
        {
            el.accept(this);
            Time.fixedDeltaTime=0.008f;
        }
        
        constForce.force = gravityForce;
        
    }
}
