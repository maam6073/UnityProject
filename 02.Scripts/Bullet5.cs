using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet5 : MonoBehaviourPun
{
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public Object impactEffect5;
    public int Dmages;


    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    [PunRPC]
    void HitTarget()
    {

        GameObject effectIns5 = PhotonNetwork.Instantiate(impactEffect5.name, transform.position, transform.rotation);
        Destroy(effectIns5, 2f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {

        Enemy e = enemy.GetComponent<Enemy>();
        Enemy1 e1 = enemy.GetComponent<Enemy1>();
        Enemy2 e2 = enemy.GetComponent<Enemy2>();
        Enemy3 e3 = enemy.GetComponent<Enemy3>();
        Enemy4 e4 = enemy.GetComponent<Enemy4>();
        Enemy5 e5 = enemy.GetComponent<Enemy5>();


        if (e != null)
        {
            e.TakeDamage(Dmages);
        }
        if (e1 != null)
        {
            e1.TakeDamage(Dmages);
        }
        if (e2 != null)
        {
            e2.TakeDamage(Dmages);
        }
        if (e3 != null)
        {
            e3.TakeDamage(Dmages);
        }
        if (e4 != null)
        {
            e4.TakeDamage(Dmages);
        }
        if (e5 != null)
        {
            e5.TakeDamage(Dmages);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
