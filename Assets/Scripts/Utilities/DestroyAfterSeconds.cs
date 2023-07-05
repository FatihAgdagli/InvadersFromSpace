using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float destroyTimeInSeconds = 2f;

    private float destroyTimer;
    //private void Start()
    //{
    //    //Destroy(gameObject, destroyTimeInSeconds);
    //}

    private void Update()
    {
        destroyTimer += Time.deltaTime;

        if( destroyTimer > destroyTimeInSeconds )
        {
            gameObject.SetActive(false);

            destroyTimer = 0;
        }
    }
}
