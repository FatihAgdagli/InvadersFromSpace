using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float destroyTimeInSeconds = 2f;

    private void Start()
    {
        Destroy(gameObject, destroyTimeInSeconds);
    }

}
