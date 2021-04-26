/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Energy Drink.cs
 * Drink that greatly increases player speed, but greatly decreases player stamina
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : Drink
{
    Meal meal;

    public EnergyDrink(Meal meal)
    {
        this.meal = meal;
    }

    public override int getSpeedBuff()
    {
        return meal.getSpeedBuff() + 5;
    }

    public override int getStamBuff()
    {
        return meal.getStamBuff() - 5;
    }

    public override int getPowerBuff()
    {
        return meal.getPowerBuff();
    }
}
