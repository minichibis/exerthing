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
    public TextMeshProUGUI energyText;
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

    public Coroutine calorieBurn;
    public Coroutine distanceLeft;
    public Coroutine energyLeft;
    //public bool started;

    #region Singleton code
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
		/*if(KeepShitPlease.k == null){
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
        */
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);

        if (SceneManager.GetActiveScene().name == "Running Scene")
        {
            calorieText = GameObject.FindGameObjectWithTag("CalorieText").GetComponent<TextMeshProUGUI>();
            energyText = GameObject.FindGameObjectWithTag("EnergyText").GetComponent<TextMeshProUGUI>();
            distText = GameObject.FindGameObjectWithTag("DistanceText").GetComponent<TextMeshProUGUI>();
            gameOver = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<TextMeshProUGUI>();

            Debug.Log("Initializing Running scene");
            time = 49;
            distance = 250;

            isRunning = true;
            calorieBurn = StartCoroutine(burnCalories());
            energyLeft = StartCoroutine(loseEnergy());
            distanceLeft = StartCoroutine(runDistance());

            killed = false;

            Debug.Log("Starting Run");
        }
        else if (SceneManager.GetActiveScene().name == "Title Scene")
        {
            Button startButton = GameObject.FindGameObjectWithTag("StartButton").GetComponent<Button>();

            startButton.onClick.AddListener(BeginRun);
        }
        else if (SceneManager.GetActiveScene().name == "Victory")
        {
            Button resetButton = GameObject.FindGameObjectWithTag("BackToStart").GetComponent<Button>();

            resetButton.onClick.AddListener(backToStart);
        }
    }

    /*public void startRun()
    {
        Debug.Log("Calling startRun");
        //started = true;

        gameOver.gameObject.SetActive(false);
        isRunning = true;
        StartCoroutine("burnCalories");
        StartCoroutine("loseEnergy");
        StartCoroutine("runDistance");

        killed = false;

        Debug.Log("Starting Run");
    }
    */

    public void endRun()
    {
        //started = false;
        Debug.Log("Ending Run");

        StopCoroutine(calorieBurn);
        StopCoroutine(energyLeft);
        StopCoroutine(distanceLeft);

        energyText.text = "Energy: 0";

        gameOver.text = "Out of Energy!";

        Invoke("LevelUp", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) //Run started
        {
            if (time > 0) //If time still remaining
            {
                calorieText.text = "Calories: " + calorieScore;
                distText.text = "Distance to go: " + (int)distance;
                energyText.text = "Energy: " + ((int)time + 1);
                if (distance <= 0){
                    //endRun(); //breaks logic
                    StopCoroutine(calorieBurn);
                    StopCoroutine(energyLeft);
                    StopCoroutine(distanceLeft);
                    //isRunning = false;
                    //killed = true; //Doesnt make sense but ok
					gameOver.text = "You Win!";

					Invoke("FinishGame", 2.0f);
				}
            }
            else if (time <= 0) //If timed out
            {
                if (!killed)
                {
                    killed = true;
                    endRun();
                }
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
        Debug.Log("Distance closing");
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

        //SceneManager.UnloadSceneAsync("Title Scene");
        //SceneManager.LoadScene("Running 2");
    }

    public void LevelUp()
    {
        
        SceneManager.LoadScene("Level Up Scene");
        StopAllCoroutines();
    }

    public void FinishGame()
    {
        isRunning = false;
        //Reset Stats
        calorieScore = 0;

        speed = 1;
        stamina = 1;
        power = 1;

        speedBuff = 0;
        stamBuff = 0;
        powerBuff = 0;

        SceneManager.LoadScene("Victory");
        //SceneManager.UnloadSceneAsync("Running Scene");
    }

    public void backToStart()
    {
        SceneManager.LoadScene("Title Scene");
        //SceneManager.UnloadSceneAsync("Victory");
    }
}
