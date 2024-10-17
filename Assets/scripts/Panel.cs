using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private float speed = 3;
    public float lifetime = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * (speed * Time.fixedDeltaTime));  //Time.deltaTime 
    }
}
