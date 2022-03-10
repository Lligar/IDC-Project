using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public bool characterIsMoving;
    float acceleration;

    void Update()
    {
        if(characterIsMoving)
        {
            if(acceleration < 0.1f)
            {
                acceleration += 0.03f * Time.deltaTime;
                acceleration = Mathf.Clamp(acceleration, 0f, 0.1f);
            }
            transform.position -= new Vector3(acceleration, 0f, 0f);
        }

        if(transform.position.x < -77.83f)
        {
            transform.position = new Vector2(-30.12f - (transform.position.x + 77.83f), transform.position.y);
        }
    }
}
