using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleJumpPrefab : Obstacle
{
    // Start is called before the first frame update
    void Start()
    {
        this.SpawnType = "Jump";
        this.CalorieValue = 0;
        this.SpawnYValue = -1.5f;
        this.minSpeed = 2;
        this.minSpeed = 5;

        //Debug.Log("HERE::::::::" + minSpeed + " " + maxSpeed);
        gameObject.AddComponent<MoveLeft>().setVars(minSpeed, maxSpeed, SpawnYValue);

    }
}
