/*
 * Liam Barrett
 * CIS 497 Spring
 * Project 6
 * Protein Bar.cs
 * Meal course that greatly increases player's power
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinBar : Meal
{
    public ProteinBar()
    {
        speedBuff = 2;
        stamBuff = 2;
        powerBuff = 2;
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
