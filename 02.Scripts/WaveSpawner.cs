using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class WaveSpawner : MonoBehaviourPun
{

    public static int EnemiesAlive = 0;
    public Object enemyPrefab;
    public Object enemy1Prefab;
    public Object enemy2Prefab;
    public Object enemy3Prefab;
    public Object enemy4Prefab;
    public Object enemy5Prefab;
    public Transform spawnPoint;


    private float countdown = 3f;

    public Text waveCountdownText;
    public Text RoundText;

    private int waveNumber = 0;

    public TextAlignment WaveCountdownText;


    private void Update()
    {

        if (RoundText.text == "0" && countdown <= 0f)
        {
            countdown = 60f;
            StartCoroutine(SpawnWave());
        }

        if (RoundText.text == "1" && countdown <= 0f)
        {
            countdown = 60f;
            StartCoroutine(SpawnWave1());

        }
        if (RoundText.text == "2" && countdown <= 0f)
        {
            countdown = 60f;
            StartCoroutine(SpawnWave2());
        }
        if (RoundText.text == "3" && countdown <= 0f)
        {
            countdown = 60f;
            StartCoroutine(SpawnWave3());
        }
        if (RoundText.text == "4" && countdown <= 0f)
        {
            countdown = 60f;
            StartCoroutine(SpawnWave4());
        }
        if (RoundText.text == "5" && countdown <= 0f)
        {
            countdown = 60f;
            StartCoroutine(SpawnWave5());
        }
        if (RoundText.text == "6" && countdown <= 0f)
        {
            PlayerStats.LIFE = 0;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
        RoundText.text = Mathf.Round(waveNumber).ToString();
    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        if (RoundText.text == "0")
        {
            for (int i = 0; i < 6; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    IEnumerator SpawnWave1()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        if (RoundText.text == "1")
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnEnemy1();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    IEnumerator SpawnWave2()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        if (RoundText.text == "2")
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnEnemy2();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    IEnumerator SpawnWave3()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        if (RoundText.text == "3")
        {
            for (int i = 0; i < 15; i++)
            {
                SpawnEnemy3();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    IEnumerator SpawnWave4()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        if (RoundText.text == "4")
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnEnemy4();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    IEnumerator SpawnWave5()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        if (RoundText.text == "5")
        {
            for (int i = 0; i < 1; i++)
            {
                SpawnEnemy5();
                yield return new WaitForSeconds(2f);
            }
        }
    }

    bool IsPresent()
    {
        bool isPresent = false;
        GameObject[] enemyArr = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyArr.Length == 20)
            isPresent = true;

        return isPresent;
    }

    void SpawnEnemy()
    {

            if (IsPresent())
                return;
            GameObject a = PhotonNetwork.Instantiate(enemyPrefab.name, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
 

        

    }
    void SpawnEnemy1()
    {
        
        if (IsPresent())
            return;
        GameObject a = PhotonNetwork.Instantiate(enemy1Prefab.name, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

    }
    void SpawnEnemy2()
    {
        if (IsPresent())
            return;
        GameObject a = PhotonNetwork.Instantiate(enemy2Prefab.name, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

    }
    void SpawnEnemy3()
    {
        if (IsPresent())
            return;
        GameObject a = PhotonNetwork.Instantiate(enemy3Prefab.name, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

    }
    void SpawnEnemy4()
    {
        if (IsPresent())
            return;
        GameObject a = PhotonNetwork.Instantiate(enemy4Prefab.name, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

    }
    void SpawnEnemy5()
    {
        if (IsPresent())
            return;
        GameObject a = PhotonNetwork.Instantiate(enemy5Prefab.name, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

    }
}
