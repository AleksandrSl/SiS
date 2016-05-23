using UnityEngine;
using System.Collections;

abstract class Element : MonoBehaviour {
    public abstract void accept(IVisitor visitor);
	}
