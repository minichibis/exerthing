/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * GameManager.cs
 * Singleton game manager that maintains player stats and score over the course of the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, ObsServ
{
    public int calorieScore;
    public Text calorieText;
	public Text engtext;

    //player stats
    public int speed;
    public int stamina;
    public int power;

    public int speedBuff;
    public int stamBuff;
    public int powerBuff;
	
	public float time;

    #region Singleton code
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" +
                "instance of singleton Game Manager");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        calorieScore = 0;
        speed = 1;
        stamina = 1;
        power = 1;

        speedBuff = 0;
        stamBuff = 0;
        powerBuff = 0;

        //only burns calories if the player is running
        if (SceneManager.GetActiveScene().name == "Running Scene")
        {
            StartCoroutine("burnCalories");
			time = 20 + stamina;
        }
        else
        {
            StopCoroutine("burnCalories");
        }
    }

    // Update is called once per frame
    void Update()
    {
        calorieText.text = "Calories: " + calorieScore;
		engtext.text = "Energy: " + ((int)time + 1);
    }

    private IEnumerator burnCalories()
    {
        //player burns calories at a rate of about 3 calories per second at base level
        for (int i = 0; i > -1; i++)
        {
            calorieScore += 1 + (power / 5) + (powerBuff / 5);
            yield return new WaitForSeconds(.3f);
        }
    }
	
	public void updateObserver()
    {
		time -= Time.deltaTime;
		if(time <= 0){
			GameObject.Find("Player").GetComponent<PlayerBehaviour>().Kill(this.gameObject);
		}
	}
}
