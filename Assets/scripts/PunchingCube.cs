using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingCube : MonoBehaviour
{
    private float speed=3;
    public float lifetime = 20;
    public int reward = 5;

    public ScoreManager scoreHandler;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * (speed * Time.fixedDeltaTime));
        //translate- moves the transform
        //Vector3.forward - (0,0,1), so along z axis, towards camera.                                                                       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "LeftGlove" || other.name == "RightGlove") //cause punch punchingcubes.
        {
            Die();  
        }
    }
    //if 'other' collides with either glove, increments score by "reward" and destroys gameobject(which is 'other' or punchingCube)
    void Die()
    {
        scoreHandler.IncrementScore(reward);  
        Destroy(gameObject);  
    }
}
