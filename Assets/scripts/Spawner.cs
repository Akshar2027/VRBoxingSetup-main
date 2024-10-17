using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation.XRDeviceSimulator;

public class Spawner : MonoBehaviour
{

    public enum CubeType   //enum is to define a set of named constants.
    {
        PunchingCube,
        DodgingCube
    }

    public GameObject punchingCube;
    public GameObject dodgingCube;
    public GameObject comboPanel;

    public Transform cubeSpawnPoint; /*This is a type in Unity that represents the position, rotation, and scale of an object in
                                     the 3D space. Every GameObject has a Transform component*/
    public Transform panelSwawnPoint;

    public ScoreManager scoreHandler;

    public float combointerval = 3;  //time interval between each set of cubes coming towards player.
    public float cubeInterval = 0.05f;

    CubeType[] combo = { CubeType.PunchingCube, CubeType.DodgingCube, CubeType.PunchingCube }; //accessing contents of enum.

    // starting is called before the first frame update
    void Start() 
    {
        InvokeRepeating("Spawn", 1, combointerval);  /*this calls Spawn method for the first time after 1 s, then repeatedly
                                                       after "combointerval" seconds */
    }

    void Spawn()
    {
        SpawnPanel();
        StartCoroutine(SpawnCubes());
    }
    
    void SpawnPanel()
    {
        Instantiate(comboPanel, panelSwawnPoint.position, panelSwawnPoint.rotation);
    }

    IEnumerator SpawnCubes()
    {
        foreach (CubeType currentCubeType in combo) {
            if (currentCubeType == CubeType.PunchingCube)
            {
                //spawn punching cube
                GameObject cube = Instantiate(punchingCube, cubeSpawnPoint.position, cubeSpawnPoint.rotation); // Code to spawn a cube
                PunchingCube punchingCubeScript = cube.GetComponent<PunchingCube>(); //his method retrieves the PunchingCube component from the newly instantiated cube. This allows you to access and modify the script's properties and methods.
                punchingCubeScript.scoreHandler = scoreHandler;  //assigning a property(scorehandler) 
            }

            else  //if current cube is dodgingCube
            {
                //spawn dodging cube
                GameObject cube = Instantiate(dodgingCube, cubeSpawnPoint.position, cubeSpawnPoint.rotation);
                DodginCube dodginCubeScript = cube.GetComponent<DodginCube>();
                dodginCubeScript.scoreHandler = scoreHandler;
            }

            yield return new WaitForSeconds(cubeInterval);
        }
    }
}
