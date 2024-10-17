using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject sphere;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
       GameObject ball = Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);

       SelfDestruct ballDestroyer = ball.GetComponent<SelfDestruct>();

       ballDestroyer.KillSelf();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
