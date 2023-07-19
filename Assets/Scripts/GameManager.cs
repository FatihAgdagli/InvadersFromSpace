using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject[] allAlienSet;

    private GameObject currentAlienSet;

    private Vector2 spawnPosition = new Vector2 (0, 10);

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

    IEnumerator SpawnWave()
    {
        if(currentAlienSet != null)
        {
            Destroy(currentAlienSet);
        }

        yield return new WaitForSeconds(3);

        UIManager.instance.UpdateWave();

        Instantiate(allAlienSet[Random.Range(0, allAlienSet.Length)],spawnPosition, Quaternion.identity);
    }
}
