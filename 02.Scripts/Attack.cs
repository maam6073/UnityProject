using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Attack : MonoBehaviourPun
{
    public Animator anim;
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
           
        }
        else
        {
            target = null;
            ANIMIDLE();
            ANIMIDLE2();
            ANIMIDLE3();
            ANIMIDLE4();
            ANIMIDLE5();
        }
    }


    void Update()
    {
        if (target == null)
            return;

        //대상 잠금 설정
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            ANIMATTACK();
            ANIMATTACK2();
            ANIMATTACK3();
            ANIMATTACK4();
            ANIMATTACK5();
            Shoot1();
            Shoot2();
            Shoot3();
            Shoot4();
            Shoot5();

            fireCountdown = 3f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot1()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }


    void Shoot2()
    {
        GameObject bulletGo2 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet2 bullet2 = bulletGo2.GetComponent<Bullet2>();

        if (bullet2 != null)
            bullet2.Seek(target);
    }

    void Shoot3()
    {
        GameObject bulletGo3 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet3 bullet3 = bulletGo3.GetComponent<Bullet3>();

        if (bullet3 != null)
            bullet3.Seek(target);
    }

    void Shoot4()
    {
        GameObject bulletGo4 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet4 bullet4 = bulletGo4.GetComponent<Bullet4>();

        if (bullet4 != null)
            bullet4.Seek(target);
    }
    void Shoot5()
    {
        GameObject bulletGo5 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet5 bullet5 = bulletGo5.GetComponent<Bullet5>();

        if (bullet5 != null)
            bullet5.Seek(target);
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void ANIMATTACK()
    {
        StartCoroutine(coANIMATTACK());
    }
    IEnumerator coANIMATTACK()
    {
        anim.SetInteger("Move", 2);
        yield return new WaitForSeconds(0.8f);
        anim.SetInteger("Move", 0);
    }
    public void ANIMIDLE()
    {
        anim.SetInteger("Move", 0);
    }

    /// <summary>
    /// Unit2
    /// </summary>
    public void ANIMATTACK2()
    {
        StartCoroutine(coANIMATTACK2());
    }
    IEnumerator coANIMATTACK2()
    {
        anim.SetInteger("Move2", 2);
        yield return new WaitForSeconds(1f);
        anim.SetInteger("Move2", 0);
    }
    public void ANIMIDLE2()
    {
        anim.SetInteger("Move2", 0);
    }

    /// <summary>
    /// Unit3
    /// </summary>
    public void ANIMATTACK3()
    {
        StartCoroutine(coANIMATTACK3());
    }
    IEnumerator coANIMATTACK3()
    {
        anim.SetInteger("Move3", 2);
        yield return new WaitForSeconds(1f);
        anim.SetInteger("Move3", 0);
    }
    public void ANIMIDLE3()
    {
        anim.SetInteger("Move3", 0);
    }

    /// <summary>
    /// Unit4
    /// </summary>
    public void ANIMATTACK4()
    {
        StartCoroutine(coANIMATTACK4());
    }
    IEnumerator coANIMATTACK4()
    {
        anim.SetInteger("Move4", 2);
        yield return new WaitForSeconds(1f);
        anim.SetInteger("Move4", 0);
    }
    public void ANIMIDLE4()
    {
        anim.SetInteger("Move4", 0);
    }


    /// <summary>
    /// Unit5
    /// </summary>
    public void ANIMATTACK5()
    {
        StartCoroutine(coANIMATTACK5());
    }
    IEnumerator coANIMATTACK5()
    {
        anim.SetInteger("Move5", 2);
        yield return new WaitForSeconds(1f);
        anim.SetInteger("Move5", 0);
    }
    public void ANIMIDLE5()
    {
        anim.SetInteger("Move5", 0);
    }
}
