using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RandomDraw : MonoBehaviourPun
{
    private PhotonView pv;

    public Object Unit1;
    public Object Unit2;
    public Object Unit3;
    public Object Unit4;
    public Object Unit5;
    public Transform UnitSpawnPoint;


    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    public void RandomUnit()
    {
        if (PlayerStats.Money >= 20)
        {
            PlayerStats.Money -= 20;
            bool randunit1 = GetThisChanceResult_Percentage(90);
            bool randunit2 = GetThisChanceResult_Percentage(45);
            bool randunit3 = GetThisChanceResult_Percentage(20);
            bool randunit4 = GetThisChanceResult_Percentage(15);
            bool randunit5 = GetThisChanceResult_Percentage(10);

            if (randunit5)
            {
                GameObject a = PhotonNetwork.Instantiate(Unit5.name, UnitSpawnPoint.position, UnitSpawnPoint.rotation);
            }
            else if (randunit4)
            {
                GameObject b = PhotonNetwork.Instantiate(Unit4.name, UnitSpawnPoint.position, UnitSpawnPoint.rotation);
            }
            else if (randunit3)
            {
                GameObject c = PhotonNetwork.Instantiate(Unit3.name, UnitSpawnPoint.position, UnitSpawnPoint.rotation);
            }
            else if (randunit2)
            {
                GameObject d = PhotonNetwork.Instantiate(Unit2.name, UnitSpawnPoint.position, UnitSpawnPoint.rotation);
            }
            else if (randunit1)
            {
                GameObject e = PhotonNetwork.Instantiate(Unit1.name, UnitSpawnPoint.position, UnitSpawnPoint.rotation);
            }
            //else MessageBox.Show("아쉽지만 꽝입니다..");





        }
    }




    public static bool GetThisChanceResult_Percentage(float Percentage_Chance)
    {
        if (Percentage_Chance < 0.0000001f)
        {
            Percentage_Chance = 0.0000001f;
        }
        Percentage_Chance = Percentage_Chance / 100;
        bool Success = false;
        int RandAccuracy = 10000000;
        float RandHitRange = Percentage_Chance * RandAccuracy;
        int Rand = UnityEngine.Random.Range(1, RandAccuracy + 1);
        if (Rand <= RandHitRange)
        {
            Success = true;
        }
        return Success;
    }

}
