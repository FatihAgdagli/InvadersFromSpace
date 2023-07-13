using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
