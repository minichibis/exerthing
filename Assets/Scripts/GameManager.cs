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
using TMPro;

public class GameManager : MonoBehaviour, ObsServ
{
    public int calorieScore;
    public TextMeshProUGUI calorieText;
    public TextMeshProUGUI energytext;
    public TextMeshProUGUI distText;
    public TextMeshProUGUI gameOver;
    //public Text engtext;
    //public Text distText;
    //public Text gameOver;
    //public GameObject[] background;
    //public GameObject[] obstacles;

    //player stats
    public int speed;
    public int stamina;
    public int power;

    public int speedBuff;
    public int stamBuff;
    public int powerBuff;

    public bool isRunning;

	public float time;
    public float distance;
	
	public bool killed;
    //public bool started;

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
            Debug.LogError("Trying to instantiate a second" +
                "instance of singleton Game Manager");
            Destroy(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        calorieScore = 0;
		if(KeepShitPlease.k == null){
			speed = 1;
			stamina = 1;
			power = 1;

			speedBuff = 0;
			stamBuff = 0;
			powerBuff = 0;
		}else{
			KeepShitPlease k = KeepShitPlease.k;
			speed = k.speed;
			stamina = k.stamina;
			power = k.power;
			speedBuff = k.speedBuff;
			stamBuff = k.stamBuff;
			powerBuff = k.powerBuff;
			Debug.Log(k.speed);
			Debug.Log(speed);
			Debug.Log(k.power);
			Debug.Log(power);
		}
        

        //This needs to move from start to allow start screen to exist
        //only burns calories if the player is running
        /*if (SceneManager.GetActiveScene().name == "Running Scene")
        {
            gameOver.gameObject.SetActive(false);
            isRunning = true;
            StartCoroutine("burnCalories");
            StartCoroutine("loseEnergy");
            StartCoroutine("runDistance");
            time = 49;
            distance = 250;
        }
        else
        {
            isRunning = false;
            StopCoroutine("burnCalories");
            StopCoroutine("loseEnergy");
            StartCoroutine("runDistance");
        }*/
		//killed = false;
    }

    public void startRun()
    {
        //started = true;

        gameOver.gameObject.SetActive(false);
        isRunning = true;
        StartCoroutine("burnCalories");
        StartCoroutine("loseEnergy");
        StartCoroutine("runDistance");
        time = 49;
        distance = 250;

        killed = false;

        Debug.Log("Starting Run");
    }

    public void endRun()
    {
        //started = false;

        isRunning = false;
        StopCoroutine("burnCalories");
        StopCoroutine("loseEnergy");
        StartCoroutine("runDistance");

        Debug.Log("Ending Run");
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) //Run started
        {
            PlayerPrefs.SetInt("Calories", calorieScore);
            calorieText.text = "Calories: " + calorieScore;
            distText.text = "Distance to go: " + (int)distance;
            if (time > 0) //If time still remaining
            {
                energytext.text = "Energy: " + ((int)time + 1);
				if(distance <= 0){
                    endRun();
                    //isRunning = false;
					killed = true; //Doesnt make sense but ok
					gameOver.gameObject.SetActive(true);
					gameOver.text = "You Win!";

					Invoke("FinishGame", 2.0f);
				}
            }
            else if (time <= 0) //If timed out
            {
                endRun();
                energytext.text = "Energy: 0";
                //background = GameObject.FindGameObjectsWithTag("MovingBackground");
                //obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                //for(int i = 0; i < background.Length; i++)
                //{
                //    background[i].GetComponent<Mover>().enabled = false;
                //}
                //for(int i = 0; i < obstacles.Length; i++)
                //{
                //    obstacles[i].GetComponent<MoveLeft>().enabled = false;
                //}
                gameOver.gameObject.SetActive(true);
				gameOver.text = "Out of Energy!";
                Invoke("LevelUp", 1.0f);
            }
        }
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

    private IEnumerator loseEnergy()
    {
        for (int i = 0; i > -1; i++)
        {
            time--;
            yield return new WaitForSeconds(.3f);
        }
    }

    private IEnumerator runDistance()
    {
        for (int i = 0; i > -1; i++)
        {
            distance -= 1 + ((float)speed * 0.1f) + ((float)speedBuff * 0.1f);
            yield return new WaitForSeconds(.3f);
        }
    }

    public void updateObserver()
    {
		time -= Time.deltaTime;
		if(time <= 0 && killed == false)
        {
			GameObject.Find("Player").GetComponent<PlayerBehaviour>().Kill(this.gameObject);
			killed = true;
		}
	}

    public void BeginRun()
    {
        SceneManager.LoadScene("Running Scene");
        //SceneManager.LoadScene("Running 2");

        startRun();
        killed = false;
    }

    public void LevelUp()
    {
        SceneManager.LoadScene("Level Up Scene");
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("Victory");
        SceneManager.UnloadSceneAsync("Running Scene");
        //Reset Stats
        calorieScore = 0;

        speed = 1;
        stamina = 1;
        power = 1;

        speedBuff = 0;
        stamBuff = 0;
        powerBuff = 0;
    }

    public void backToStart()
    {
        SceneManager.LoadScene("Title Scene");
        SceneManager.UnloadSceneAsync("Victory");

    }
}
