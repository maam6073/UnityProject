using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfTimerDestroy : MonoBehaviour
{
    float currTime = 0f;

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime >= 2f)
            Destroy(gameObject);
    }
}
