using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour,IEnemy
{
    [SerializeField] private int scorePoint = 1000;

    [SerializeField] GameObject explosionPrefab;

    [SerializeField] private float speed = 5f;

    private const float MAX_LEFT = -6f;

    public static EventHandler OnKill;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < MAX_LEFT)
        {
            gameObject.SetActive(false);
        }
    }

    public void Kill()
    {
        OnKill?.Invoke(this, EventArgs.Empty);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        gameObject.SetActive(false);

        UIManager.instance.UpdateScore(scorePoint);
    }
}
