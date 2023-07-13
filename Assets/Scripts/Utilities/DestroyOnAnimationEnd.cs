using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    [SerializeField] private float destroyDelayInSecond = 1f;

    private void Start()
    {
        Animator animator = GetComponent<Animator>();

        float destroyTime = animator.GetNextAnimatorStateInfo(0).length + destroyDelayInSecond;

        Destroy(gameObject, destroyTime);
    }
}
