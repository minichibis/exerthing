using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public int randomSpeed = 1;
     
    public void setVars(int min, int max, float height)
    {
        //Set randomVariable
        randomSpeed = (Random.Range(min+1, max+1));

        //Set Height
        transform.position = new Vector2(10, height);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += transform.right * -randomSpeed * Time.deltaTime;
    }
}