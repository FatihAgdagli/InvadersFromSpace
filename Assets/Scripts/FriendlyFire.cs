using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFire : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            collision.gameObject.GetComponent<Alien>().Kill();
            
            gameObject.SetActive(false);

        }
        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            collision.gameObject.SetActive(false);
            
            gameObject.SetActive(false);
        }
    }
}
