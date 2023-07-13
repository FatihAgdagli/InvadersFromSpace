using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStat 
{
    private int maxHealt = 3;
    private int maxLife = 2;

    private int currentHealt;
    private int currentLife;

    public ShipStat() 
    {
        currentHealt = maxHealt;
        currentLife = maxLife;
    }

    public bool TakeDamege()
    {
        currentHealt--;

        if (currentHealt > 0)
        {
            return false;
        }

        currentLife--;

        if (currentLife > 0)
        {
            return false;
        }

        return true;
    }

    public void StartNewLife()
    {
        currentHealt = maxHealt;
    }

    public int GetHealt() => currentHealt;
    public int GetLife() => currentLife;

}
