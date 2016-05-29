using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Attractable), typeof(Collider2D))]
    public class Movable: MonoBehaviour
    {
        
        [HideInInspector]
        public string ClassName;
        [HideInInspector]
        public int ClassIndex;
        [HideInInspector]
        public string MethodName;
        [HideInInspector]
        public int MethodIndex;
        [HideInInspector]
        public MethodInfo Method;

        private static float TimeStep = 0.01f;

        internal Attractable Attr;
        private Vector3 _coord = Vector3.zero;
        
        protected Type Type;
        

        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        protected void MovementStep()
        {
            Acceleration = Attr.getGravityField();
            Velocity += Acceleration * TimeStep;
            _coord = new Vector3(Velocity.x * TimeStep, Velocity.y * TimeStep, 0);
            transform.Translate(_coord);
        }

        protected void MovementStep(MethodInfo method)
        {
            Acceleration = Attr.getGravityField();
            Velocity += Acceleration * TimeStep;
            _coord = new Vector3(Velocity.x * TimeStep, Velocity.y * TimeStep, 0);
            transform.Translate(_coord);
            Debug.Log(this);
            method.Invoke(this.gameObject, null);
            //method.Invoke(this, null);
            
        }



    }
}
