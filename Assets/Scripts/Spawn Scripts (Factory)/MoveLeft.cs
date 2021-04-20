using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float randomSpeed = 1f;
     
    public void setVars(int min, int max, float height)
    {
        //Set randomVariable
        randomSpeed = (float)(Random.Range(min+1, max+1));
		randomSpeed = 5.5f;

        //Set Height
        transform.position = new Vector2(10, height);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += transform.right * -randomSpeed * Time.deltaTime;
    }
}