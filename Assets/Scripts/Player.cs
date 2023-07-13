using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    [SerializeField] private float bulletCoolDownInSecond = 0.5f;

    [SerializeField] private ObjectPool objectPool;

    [SerializeField]private float respawnTime = 2f;

    private float width;

    private bool isShooting;

    private ShipStat shipStat;


    private Vector2 offShipPosition = new Vector2(0, -20);

    private Vector2 startPosition = new Vector2(0, -6);

    private void Start()
    {
        width = GameManager.instance.ScreenWidth;

        shipStat = new ShipStat();

        transform.position = startPosition;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > -width)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < width)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && !isShooting) 
        { 
            StartCoroutine(Shoot());
        }
#endif
    }

    private IEnumerator Shoot()
    {
        isShooting = true;

        GameObject bullet = objectPool.GetPooledObject();

        bullet.transform.position = transform.position;

        yield return new WaitForSeconds(bulletCoolDownInSecond);

        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offShipPosition;

        yield return new WaitForSeconds(respawnTime);

        shipStat.StartNewLife();

        transform.position = startPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {

            if (shipStat.TakeDamege())
            {
                Debug.Log("Game Over");
            }
            else
            {
                StartCoroutine(Respawn());
            }
            Debug.Log($"Healt: {shipStat.GetHealt()} , Life: {shipStat.GetLife()}");
        }
    }
}
