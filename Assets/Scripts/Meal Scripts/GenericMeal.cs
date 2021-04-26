using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMeal : Meal
{
    public GenericMeal()
    {
        speedBuff = 0;
        stamBuff = 0;
        powerBuff = 0;
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