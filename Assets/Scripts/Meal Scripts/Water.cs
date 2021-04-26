/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Water.cs
 * Drink that increases all player stats considerably
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Drink
{
    Meal meal;

    public Water(Meal meal)
    {
        this.meal = meal;
    }

    public override int getSpeedBuff()
    {
        return meal.getSpeedBuff() + 3;
    }

    public override int getStamBuff()
    {
        return meal.getStamBuff() + 3;
    }

    public override int getPowerBuff()
    {
        return meal.getPowerBuff() + 3;
    }
}
