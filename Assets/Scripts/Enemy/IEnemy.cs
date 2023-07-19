using System;

public interface IEnemy
{
    public static EventHandler OnKill;
    public void Kill();
}
