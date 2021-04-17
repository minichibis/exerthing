using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPrefab : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        this.SpawnType = "Background";
        this.CalorieValue = 0;
        this.SpawnYValue = 0;
        this.minSpeed = 8;
        this.minSpeed = 12;
        //this.FindLayer = ?;

        //Debug.Log("HERE::::::::" + minSpeed + " " + maxSpeed);
        gameObject.AddComponent<MoveLeft>().setVars(minSpeed, maxSpeed, SpawnYValue);

    }
}
