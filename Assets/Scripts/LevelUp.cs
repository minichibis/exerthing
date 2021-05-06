using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{
    GameManager gameManager;
	KeepShitPlease k;

    [SerializeField]private int speedUpCount;
    [SerializeField]private int stamUpCount;
    [SerializeField]private int powerUpCount;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI caloriesText;

    void Start()
    {
        gameManager = GameManager.instance;
		//k = KeepShitPlease.k;
        speedUpCount = 0;
        stamUpCount = 0;
        powerUpCount = 0;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level Up Scene")
        {
            caloriesText.text = "Calories: " + gameManager.calorieScore;
            speedText.text = "" + (gameManager.speed + speedUpCount);
            staminaText.text = "" + (gameManager.stamina + stamUpCount);
            powerText.text = "" + (gameManager.power + powerUpCount);
        }
    }

    private void resetLevelUp()
    {
        speedUpCount = 0;
        stamUpCount = 0;
        powerUpCount = 0;
    }

    public void increaseSpeed()
    {
        if (gameManager.calorieScore >= 10)
        {
            speedUpCount++;
            gameManager.calorieScore -= 10;
        }
    }

    public void decreaseSpeed()
    {
        if (speedUpCount > 0)
        {
            speedUpCount--;
            gameManager.calorieScore += 10;
        }
    }

    public void increaseStamina()
    {
        if (gameManager.calorieScore >= 10)
        {
            stamUpCount++;
            gameManager.calorieScore -= 10;
        }
    }

    public void decreaseStamina()
    {
        if (stamUpCount > 0)
        {
            stamUpCount--;
            gameManager.calorieScore += 10;
        }
    }

    public void increasePower()
    {
        if (gameManager.calorieScore >= 10)
        {
            powerUpCount++;
            gameManager.calorieScore -= 10;
        }
    }

    public void decreasePower()
    {
        if (powerUpCount > 0)
        {
            powerUpCount--;
            gameManager.calorieScore += 10;
        }
    }

    public void finish()
    {
        gameManager.speed += speedUpCount;
        gameManager.stamina += stamUpCount;
        gameManager.power += powerUpCount;
		//k.speed += speedUpCount;
        //k.stamina += stamUpCount;
        //k.power += powerUpCount;

        resetLevelUp();
        //PlayerPrefs.DeleteKey("Calories");
        SceneManager.LoadScene("Meal Scene");
        SceneManager.UnloadSceneAsync("Level Up Scene");
    }
}
