using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DodginCube : MonoBehaviour
{
    public float speed = 2;
    public float lifetime = 20;
    public int punishment = 15;

    public ScoreManager scoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * (speed * Time.fixedDeltaTime));  //Time.deltaTime 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Main Camera")  // cause you have to duck dodgingcube.
        {
            Die();
        }
    }
    //if 'other' collides with either glove, increments score by "punishment" and destroys gameobject(which is 'other' or dodgingCube)
    void Die()
    {
        scoreHandler.IncrementScore(-punishment);
        Destroy(gameObject);
    }
}
