/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Meal.cs
 * Abstract class for the meal items the player eats before each run
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Meal
{
    public int speedBuff = 0;
    public int stamBuff = 0;
    public int powerBuff = 0;

    public abstract int getSpeedBuff();
    public abstract int getStamBuff();
    public abstract int getPowerBuff();
}
