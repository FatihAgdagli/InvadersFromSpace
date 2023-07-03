using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;

    private Camera cam;

    private float width;

    [SerializeField] private float speed = 3f;

    [SerializeField] private float bulletCoolDownInSecond = 0.5f;

    private bool isShooting;

    private void Awake()
    {
        cam = Camera.main;

        width = ((1 / (cam.WorldToViewportPoint(new Vector3(1,1,0)).x - 0.5f) / 2) - 0.25f);
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

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(bulletCoolDownInSecond);

        isShooting = false;
    }

}
