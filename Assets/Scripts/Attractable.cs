using UnityEngine;
using System.Collections;
using System;


class Attractable : MonoBehaviour, IVisitor { 
    ConstantForce2D constForce;
    Rigidbody2D rb2d;
    Movable movement;
    
    Element[] elements;
    
    Vector2 gravityField;
   
    public void visitElement(Attractor attractor) {
        
        gravityField += calculateForce(attractor.getMass(), attractor.getPosition()); // Прибавить силу действующую со стороны Attractor
    }
    public void visitElement(Repulser repulser) {
        
        gravityField -= calculateForce(repulser.getMass(), repulser.getPosition()); // Вычесть силу действующую со стороны Repulser

    }
    void Awake()
    {

        constForce = GetComponent<ConstantForce2D>();
        rb2d = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movable>();
        elements = FindObjectsOfType(typeof(Element)) as Element[];

    }
    
    
    public Vector2 calculateForce(float attractorMass, Vector2 attractorPosition) {
        float angle;
        float dist = Vector2.Distance(attractorPosition, this.transform.position);
        Vector2 forceVect = attractorPosition - (Vector2)transform.position;
        if (attractorPosition.x < transform.position.x){  // Так как угол определяемый Vector2.Angle() у меня получался от 0 до 180
            angle = (360 - (Vector2.Angle(forceVect, Vector2.up)))*Mathf.PI/180.0f;
        }
        else {
            angle = (Vector2.Angle(forceVect, Vector2.up)) * Mathf.PI / 180.0f;
        }
        float gravityFieldValue =(attractorMass)/(dist*dist);
        
        return new Vector2((gravityFieldValue * Mathf.Sin(angle)), (gravityFieldValue * Mathf.Cos(angle)));
        
        
        }

    public  Vector2 getGravityField() {

        gravityField = Vector2.zero;
        foreach (Element el in elements)   //я не очень представляю, как правильно сложить силы, если это дело реализовать как положено в element, то каждый объект element будет по отдельности по очереди тянуть)
        {
            el.accept(this);
            
        }
        return gravityField;
    

    }
}
