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
}
