using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy5 : MonoBehaviour
{
    WaveSpawner spawner;
    public float StartHealth = 1500;
    public float Health = 1500;
    public float speed = 1f;

    private Transform target;
    private int wavePointIndex = 0;
    GameManagers gm = new GameManagers();

    void Start()
    {
        target = WayPoint.points[0];
    }
    public void TakeDamage (int amount)
    {
        Health -= amount;

        if(Health <= 0f)
        {
            Die();
            SceneManager.LoadScene("03.EndingScene");
        }
    }

    void Die()
    {
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Money += 20;
    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavePointIndex >= WayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = WayPoint.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.LIFE--;
        Destroy(gameObject);
    }








}
