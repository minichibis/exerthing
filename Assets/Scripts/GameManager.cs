using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int calorieScore;
    public Text calorieText;

    //player stats
    public int speed;
    public int stamina;
    public int power;

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

        //only burns calories if the player is running
        if (SceneManager.GetActiveScene().name == "Running Scene")
        {
            StartCoroutine("burnCalories");
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
    }

    private IEnumerator burnCalories()
    {
        //player burns calories at a rate of about 1 calories per second
        for (int i = 0; i > -1; i++)
        {
            calorieScore++;
            yield return new WaitForSeconds(.3f);
        }
    }
}
