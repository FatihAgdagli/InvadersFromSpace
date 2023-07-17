using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private Sprite[] states;

    private int health;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        health = 4;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || 
            collision.gameObject.CompareTag("PlayerBullet"))
        {
            health--;

            collision.gameObject.SetActive(false);
            
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = states[health - 1];
            }
        }
    }

}
