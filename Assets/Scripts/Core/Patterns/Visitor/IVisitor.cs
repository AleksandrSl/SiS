using UnityEngine;
using System.Collections;

interface  IVisitor {
    void visitElement(Attractor attractor);
    void visitElement(Repulser repulser);
 
}
