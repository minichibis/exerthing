/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Burger.cs
 * Meal course that generally lowers the player's stats. Could be used for a challenge run if the player felt like it
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : Meal
{
    public Burger()
    {
        speedBuff = -1;
        stamBuff = -1;
        powerBuff = 1;
    }

    public override int getSpeedBuff()
    {
        return this.speedBuff;
    }

    public override int getStamBuff()
    {
        return this.stamBuff;
    }

    public override int getPowerBuff()
    {
        return this.powerBuff;
    }
}
