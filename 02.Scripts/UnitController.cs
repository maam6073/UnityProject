using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class UnitController : MonoBehaviourPun
{
    public Animator anim;
    private NavMeshAgent navAgent;
    private Transform currentTarget;
    private float attackTimer;
    private PhotonView pv;
    

    public UnitStats UnitStats;

    public void Start()
    {
        pv = GetComponent<PhotonView>();
        navAgent = GetComponent<NavMeshAgent>();
        attackTimer = UnitStats.attackSpeed;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if(currentTarget != null)
        {
            navAgent.destination = currentTarget.position;

            var distance = (transform.position - currentTarget.position).magnitude;

            if(distance <= UnitStats.attackRange)
            {
                Attack();
            }
        }
    }

    public void MoveUnit(Vector3 dest)
    {
        currentTarget = null;
        navAgent.destination = dest;
        ANIMWALK();
        ANIMWALK2();
        ANIMWALK3();
        ANIMWALK4();
        ANIMWALK5();

    }

    public void SetSelected(bool isSelected)
    {
        transform.Find("Highlight").gameObject.SetActive(isSelected);
    }

    public void SetNewTarget(Transform enemy)
    {
        currentTarget = enemy;
    }

    public void Attack()
    {
        if(attackTimer >= UnitStats.attackSpeed)
        {
            RTSGameManager.UnitTakeDamage(this, currentTarget.GetComponent<UnitController>());
            attackTimer = 0;
        }
        
    }
    public void TakeDamage(UnitController enemy, float damage)
    {
        StartCoroutine(Flasher(GetComponent<Renderer>().material.color));
    }

    IEnumerator Flasher(Color defaultColor)
    {
        var renderer = GetComponent<Renderer>();
        for(int i = 0; i < 2; i++)
        {
            renderer.material.color = Color.gray;
            yield return new WaitForSeconds(.05f);
            renderer.material.color = defaultColor;
            yield return new WaitForSeconds(.05f);
        }
    }

    public void ANIMWALK()
    {
        anim.SetInteger("Move", 1);
    }
    public void ANIMWALK2()
    {
        anim.SetInteger("Move2", 1);
    }

    public void ANIMWALK3()
    {
        anim.SetInteger("Move3", 1);
    }

    public void ANIMWALK4()
    {
        anim.SetInteger("Move4", 1);
    }
    public void ANIMWALK5()
    {
        anim.SetInteger("Move5", 1);
    }
}
