using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Camera cam;
    public float ScreenWidth { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        cam = Camera.main;

        ScreenWidth = ((1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f) / 2) - 0.25f);
    }
}
