using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private const float MAX_LEFT = -6f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < MAX_LEFT)
        {
            gameObject.SetActive(false);
        }
    }
}
