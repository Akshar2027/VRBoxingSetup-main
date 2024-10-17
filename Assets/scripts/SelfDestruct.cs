using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float speed = 0.05f;
    public void KillSelf()
    {
        Destroy(gameObject, 2);
    }

    public void Update()
    {
        //Vector3 dir = new Vector(0,0,1);   //THIS IS ALT WAY TO WRITE Vector.forward
        transform.Translate(Vector3.forward * speed);
    }
}
