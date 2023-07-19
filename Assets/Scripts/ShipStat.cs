using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStat 
{
    private int maxHealt = 5;
    private int maxLife = 3;

    private int currentHealt;
    private int currentLife;

    public ShipStat() 
    {
        currentHealt = maxHealt;
        currentLife = maxLife;

        UIManager.instance.UpdateLives(currentLife);
        UIManager.instance.UpdateHealtBar(currentHealt);
    }

    public bool TakeDamege()
    {
        currentHealt--;
        UIManager.instance.UpdateHealtBar(currentHealt);
        if (currentHealt > 0)
        {
            return false;
        }

        StartNewLife();

        currentLife--;
        UIManager.instance.UpdateLives(currentLife);
        if (currentLife > 0)
        {
            return false;
        }

        return true;
    }

    public void StartNewLife()
    {
        currentHealt = maxHealt;

        UIManager.instance.UpdateHealtBar(currentHealt);
    }

    public int GetHealt() => currentHealt;
    public int GetLife() => currentLife;

}
