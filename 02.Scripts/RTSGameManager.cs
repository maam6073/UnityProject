using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSGameManager : MonoBehaviour
{
 
    public static void UnitTakeDamage(UnitController attackingController, UnitController attackedController)
    {
        var damage = attackedController.UnitStats.attackDamage;

        attackedController.TakeDamage(attackedController, damage);
    }
}
