/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Spaghetti.cs
 * Meal course that gives a major buff to stamina
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaghetti : Meal
{
    public Spaghetti()
    {
        //mild increases in speed and power for eating, big increase in stamina because of carbs
        speedBuff = 1;
        stamBuff = 5;
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
