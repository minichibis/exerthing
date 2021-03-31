using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int calorieScore;
    public Text calorieText;

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
    }

    // Update is called once per frame
    void Update()
    {
        //only increments the calorieScore if the player is running
        if (SceneManager.GetActiveScene().name == "Running Scene")
        {
            StartCoroutine("burnCalories");
        }
        else
        {
            StopCoroutine("burnCalories");
        }

        calorieText.text = "Calories: " + calorieScore;
    }

    private IEnumerator burnCalories()
    {
        //player burns calories at a rate of about 3.3 calories per second
        calorieScore++;
        yield return new WaitForSeconds(.3f);
    }
}
