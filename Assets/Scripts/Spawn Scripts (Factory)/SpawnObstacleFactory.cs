using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleFactory : MonoBehaviour
{
    public GameObject obstacleCrouchPrefab;
    public GameObject obstacleJumpPrefab;
    //public GameObject backgroundPrefab;
    
    private GameObject spawnToCreate;
    
    public GameObject CreateSpawn(string type)
    {
        spawnToCreate = null;

        //Implement fancy stuff later
        /*
        if (type.Equals("Background"))
        {
            spawnToCreate = backgroundPrefab;

            //If there is not already a  script attached to the prefab, attach one
            if (spawnToCreate.GetComponent<BackgroundPrefab>() == null)
            {
                spawnToCreate.AddComponent<BackgroundPrefab>();
            }
        }*/
        /*else*/ if (type.Equals("Crouch"))
        {
            spawnToCreate = obstacleCrouchPrefab;

            //If there is not already a Vampire script attached to the prefab, attach one
            if (spawnToCreate.GetComponent<ObstacleCrouchPrefab>() == null)
            {
                spawnToCreate.AddComponent<ObstacleCrouchPrefab>();
            }
        }
        else if (type.Equals("Jump"))
        {
            spawnToCreate = obstacleJumpPrefab;

            //If there is not already a Werewolf script attached to the prefab, attach one
            if (spawnToCreate.GetComponent<ObstacleJumpPrefab>() == null)
            {
                spawnToCreate.AddComponent<ObstacleJumpPrefab>();
            }
        }
        //Debug.Log("Factory sending: " + spawnToCreate);
        return spawnToCreate;
    }
}
