using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Range of how fast obstacles approach the player
    protected int minSpeed { get; set; }
    protected int maxSpeed { get; set; }
    protected string SpawnType { get; set; }
    protected int CalorieValue { get; set; }
    protected float SpawnYValue { get; set; }

    protected private void Update()
    {
        //Move the object to the left        
        //Might not do movement if player lost all lives/gameIsOver

        //***** None of these work so implemented work arounds *****

        //transform.Translate(transform.forward); 
        //this.transform.Translate(new Vector3(10,SpawnYValue,0) * randomSpeed);
        //rigidbody.AddForce(new Vector2(-randomSpeed, 1) * 10);
        //transform.position += transform.right * -randomSpeed * Time.deltaTime;

        //Might have problems with rewinding gameplay if conditional destroys the object 
        //Maybe only rewind just a little bit after getting hit to try the obstacle again?
        if (gameObject.transform.position.x < -8.2) //Max value here dependent on scene transforms 
        {                                          //(might turn into variable)
            Die();
        }
    }

    protected private void Awake()
    {
        //Set position based on prefab                            //v
        this.transform.position = new Vector2(10, SpawnYValue); //v

        //Set randomVariable //-> moved to workaround below //v
        //randomSpeed = (Random.Range(minSpeed, maxSpeed)); //v

    }


    public void Die()
    {
        //Might try to add to the rewind check that this object was destroyed at this 
        //point to instantiate at where it would be destroyed when rewinding
        
        Destroy(gameObject);
    }

    public void AffectCalories(int value)
    {
        //Reference to whatever script is handling local 
        //scoring of level/what adding acculated calorie points to
        //GameManager gameManager = FindObjectOfType<GameManager>();
        //gameManager.UpdateScore(PointValue);
    }

    //Wait to implement fully -> Mainly for spawning of background assets to be differentiated in scene
    
    public void FindLayer()
    {
        //Set position of y range to specified value set in other specific prefab script
        
    }

    public override string ToString()
    {
        return "SpawnType: " + this.SpawnType + "\n" +
                  "CalorieValue: " + this.CalorieValue + "\n" +
                  "SpawnYValue: " + this.SpawnYValue + "\n";
    }
}

