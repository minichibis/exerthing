/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Drink.cs
 * Abstract class for the drinks that the player can have with their food
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drink : Meal
{
    public abstract override int getSpeedBuff();
    public abstract override int getStamBuff();
    public abstract override int getPowerBuff();
}
