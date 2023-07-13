using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private int scorePoint = 1;

    [SerializeField] GameObject explosionPrefab;

    public static EventHandler OnKill;

    public void Kill()
    {
        OnKill?.Invoke(this, EventArgs.Empty);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }
}
