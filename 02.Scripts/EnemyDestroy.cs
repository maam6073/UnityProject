using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    float EnemyTime = 0f;

    private void Update()
    {
        EnemyTime += Time.deltaTime;
        if (EnemyTime >= 50f)
            Destroy(gameObject);
    }
}
