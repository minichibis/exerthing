﻿using System.Collections;
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
		k = KeepShitPlease.k;
        speedUpCount = 0;
        stamUpCount = 0;
        powerUpCount = 0;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level Up Scene")
        {
            caloriesText.text = "Calories: " + PlayerPrefs.GetInt("Calories");
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
        if (PlayerPrefs.GetInt("Calories") >= 10)
        {
            speedUpCount++;
            PlayerPrefs.SetInt("Calories", PlayerPrefs.GetInt("Calories") - 10);
        }
    }

    public void decreaseSpeed()
    {
        if (speedUpCount > 0)
        {
            speedUpCount--;
            PlayerPrefs.SetInt("Calories", PlayerPrefs.GetInt("Calories") + 10);
        }
    }

    public void increaseStamina()
    {
        if (PlayerPrefs.GetInt("Calories") >= 10)
        {
            stamUpCount++;
            PlayerPrefs.SetInt("Calories", PlayerPrefs.GetInt("Calories") - 10);
        }
    }

    public void decreaseStamina()
    {
        if (stamUpCount > 0)
        {
            stamUpCount--;
            PlayerPrefs.SetInt("Calories", PlayerPrefs.GetInt("Calories") + 10);
        }
    }

    public void increasePower()
    {
        if (PlayerPrefs.GetInt("Calories") >= 10)
        {
            powerUpCount++; 
            PlayerPrefs.SetInt("Calories", PlayerPrefs.GetInt("Calories") - 10);
        }
    }

    public void decreasePower()
    {
        if (powerUpCount > 0)
        {
            powerUpCount--;
            PlayerPrefs.SetInt("Calories", PlayerPrefs.GetInt("Calories") + 10);
        }
    }

    public void finish()
    {
        gameManager.speed += speedUpCount;
        gameManager.stamina += stamUpCount;
        gameManager.power += powerUpCount;
		k.speed += speedUpCount;
        k.stamina += stamUpCount;
        k.power += powerUpCount;

        resetLevelUp();
        PlayerPrefs.DeleteKey("Calories");
        SceneManager.LoadScene("Meal Scene");
    }
}
