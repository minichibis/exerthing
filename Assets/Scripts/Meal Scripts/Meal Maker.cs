using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealMaker : MonoBehaviour
{
    public Meal meal;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.instance;
        DisplayMeal();
    }

    public void DisplayMeal()
    {

    }
}
