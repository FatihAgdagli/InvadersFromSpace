using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    private const float MAX_RIGHT = 2f;
    private const float MAX_LEFT = -2f;
    private const float MAX_MOVE_SPEED = 0.02f;

    [SerializeField] private GameObject bulletPrefab;

    private List<GameObject> alienList = new List<GameObject>();

    private bool movingRight;

    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private Vector3 hMoveDistance = new Vector3 (0, 0, 0);
    private Vector3 vMoveDistance = new Vector3 (0, 0, 0);


    private void Start()
    {
        alienList = GameObject.FindGameObjectsWithTag("Alien").ToList<GameObject>();
    }

    private void Update()
    {
        if (moveTimer <= 0)
        {
            MoveAliens();
        }
        moveTimer -= Time.deltaTime;
    }

    private void MoveAliens()
    {
        int hitMax = 0;

        for (int i = 0; i < alienList.Count; i++)
        {
            if(movingRight)
            {
                alienList[i].transform.position += hMoveDistance;
            }
            else
            {
                alienList[i].transform.position -= hMoveDistance;
            }

            if (alienList[i].transform.position.x > MAX_RIGHT || alienList[i].transform.position.x < MAX_LEFT)
            {
                hitMax++;
            }
        }

        if (hitMax > 0)
        {
            for (int i = 0; i < alienList.Count; i++)
            {
                alienList[i].transform.position -= vMoveDistance;
            }

            movingRight = !movingRight;
        }

        moveTimer = GetMovedSpeed();
    }

    private float GetMovedSpeed()
    {
        float f = alienList.Count * moveTime;

        if (f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }
}
