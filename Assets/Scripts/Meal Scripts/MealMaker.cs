using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MealMaker : MonoBehaviour
{
    public Meal meal;
    public GameManager gameManager;
    public Text buffText;
    private bool drinkSet;

    void Awake()
    {
        gameManager = GameManager.instance;
        drinkSet = false;
        DisplayMeal();
    }

    public void setMainCourse(string newMeal)
    {
        switch (newMeal)
        {
            case "Spaghetti":
                this.meal = new Spaghetti();
                break;
            case "Burger":
                this.meal = new Burger();
                break;
            case "Protein Bar":
                this.meal = new ProteinBar();
                break;
            default:
                Debug.LogError("No main course selected");
                break;
        }
        DisplayMeal();
        drinkSet = false;
    }

    public void setDrink(string newDrink)
    {
        if (!drinkSet)
        {
            switch (newDrink)
            {
                case "Energy Drink":
                    this.meal = new EnergyDrink(meal);
                    break;
                case "Water":
                    this.meal = new Water(meal);
                    break;
            }
            drinkSet = true;
        }
        DisplayMeal();
    }

    public void finish()
    {
        gameManager.speedBuff = meal.getSpeedBuff();
        gameManager.stamBuff = meal.getStamBuff();
        gameManager.powerBuff = meal.getPowerBuff();

        SceneManager.LoadScene("Running Scene");
    }

    public void DisplayMeal()
    {
        buffText.text = "Speed: +" + meal.getSpeedBuff() + "\nStamina: +" + meal.getStamBuff()
            + "\nPower: +" + meal.getPowerBuff();
    }
}
