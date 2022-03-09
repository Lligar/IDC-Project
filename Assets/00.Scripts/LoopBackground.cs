using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if(transform.position.x < -77.83f)
        {
            transform.position = new Vector2(-30.12f - (transform.position.x + 77.83f), transform.position.y);
        }
    }
}
