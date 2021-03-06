using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool cooledDown = true;
    public bool toggleSpawn = false;

    private string tempSpawn;
	
	public float min;
	public float max;
	
	public bool first = true;

    //Need to attach the simple factory GameObject to this reference in the inspector
    public SpawnObstacleFactory factory;

    private GameObject spawn;
	
	void Start()
    {
		min = 2.5f;
		max = 3.75f;
	}

    private void Update()
    {
        //Some conditional that if true, spawn prefabs
        /*if (Input.GetKey(KeyCode.Space))
        {

            if (cooledDown == true)
            {
                Debug.Log("Got to spawning");
                StartCoroutine(SpawnTarget());

                cooledDown = false;
            }
        }
        */
        if (cooledDown == true)
        {
            cooledDown = false;
            StartCoroutine(SpawnTarget());
        }

        /*    
        if (Input.GetKey(KeyCode.B))
        {
            SpawnObject("Crouch");
        }
        if (Input.GetKey(KeyCode.N))
        {
            SpawnObject("Jump");
        }
        */

        /*
        if (Input.GetKey(KeyCode.M))
        {
            SpawnObject("Background");
        }*/
    }

    IEnumerator SpawnObject(string type)
    {
        //Debug.Log("Type passed in: " + type);
        spawn = factory.CreateSpawn(type);
        //Debug.Log(spawn);

        //Switch to instead changing layer that spawn is set to
        //Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
		
		
        Instantiate(spawn, spawn.transform.position, spawn.transform.rotation);
        //Instantiate(spawn, Vector2(0,0,0), spawn.transform.rotation);
        //cooledDown = true;
        //float temp = Random.Range(1f, 3f);
        yield return new WaitForSeconds(.1f);
    }

    
    
    //If dont want to manually choose between jump/crouch prefabs 
    IEnumerator SpawnTarget()
    {
        //Debug.Log("Got to SpawnTarget begin");
        //yield return new WaitForSeconds(0.25f);

        //Pick a random index between 0 and number of prefabs
        int index = Random.Range(0, 2);

        if (index == 0)
        {
            tempSpawn = "Crouch";
        }
        else if (index == 1)
        {
            tempSpawn = "Jump";
        }
        //Debug.Log("Type: " + tempSpawn);

		if(!first){
        spawn = factory.CreateSpawn(tempSpawn);
        Instantiate(spawn, spawn.transform.position, spawn.transform.rotation);
		}
		
		first = false;
        
        //SpawnObject(tempSpawn);

        float temp = Random.Range(min, max);
        yield return new WaitForSeconds(temp);
        
        cooledDown = true;
		
		min -= 0.1f;
		max -= 0.2f;
		
		min = Mathf.Max(min, 0.95f);
		max = Mathf.Max(max, min + 0.75f);
        
        
        //Debug.Log("Got to SpawnTarget End");
        
    }
}
