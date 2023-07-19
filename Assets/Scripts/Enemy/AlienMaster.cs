using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlienMaster : MonoBehaviour
{
    private const float MAX_MOVE_SPEED = 0.02f;
    private float maxRight = 3f;
    private float maxLeft = -3f;

    [SerializeField] private ObjectPool bulletPool;

    private List<GameObject> alienList = new List<GameObject>();

    private bool movingRight;

    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private float shootTimer = 3f;
    private float shootTime = 3f;

    private Vector3 hMoveDistance = new Vector3 (0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3 (0, 0.15f, 0);

    [SerializeField] private ObjectPool motherShipPool;
    private Vector3 motherShitPosition = new Vector3(6, 4.5f, 0);
    private float motherShipTimer = 5f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    private void Start()
    {
        alienList = GameObject.FindGameObjectsWithTag("Alien").ToList<GameObject>();

        Alien.OnKill += Alien_OnKill;

        maxRight = GameManager.instance.ScreenWidth - 0.15f;
        maxLeft = -GameManager.instance.ScreenWidth + 0.15f;
    }

    private void Alien_OnKill(object sender, EventArgs e)
    {
        Alien alien = sender as Alien;

        alienList.Remove(alien.gameObject);
    }

    private void Update()
    {
        OnTimerElapsed(MoveAliens, ref moveTimer);

        OnTimerElapsed(Shoot, ref shootTimer);

        OnTimerElapsed(SpawnMotherShip, ref motherShipTimer);
    }

    private void SpawnMotherShip()
    {
        GameObject motherShip = motherShipPool.GetPooledObject();

        motherShip.transform.position = motherShitPosition;

        motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }

    private void Shoot()
    {
        if (alienList.Count < 1)
        {
            return;
        }

        Vector3 bulletPosition = alienList[Random.Range(0, alienList.Count)].transform.position;

        GameObject bullet = bulletPool.GetPooledObject();

        bullet.transform.position = bulletPosition;

        shootTimer = shootTime;
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

            if (alienList[i].transform.position.x > maxRight || alienList[i].transform.position.x < maxLeft)
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

    private void OnTimerElapsed(Action actionFinished, ref float timer)
    {
        if (timer <= 0)
        {
            actionFinished.Invoke();
        }

        timer -= Time.deltaTime;
    }

}
