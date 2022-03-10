using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public bool characterIsMoving;
    public float acceleration;

    void Update()
    {
        print(acceleration);
        if(characterIsMoving)
        {
            if(acceleration < 0.05f)
            {
                acceleration += 0.045f * Time.deltaTime;
                acceleration = Mathf.Clamp(acceleration, 0f, 0.05f);
            }
            transform.position -= new Vector3(acceleration, 0f, 0f);
        }
        else
        {
            if (acceleration > 0f)
            {
                acceleration -= 0.045f * Time.deltaTime;
                acceleration = Mathf.Clamp(acceleration, 0f, 0.05f);
            }
            transform.position -= new Vector3(acceleration, 0f, 0f);
        }

        if (transform.position.x < -77.83f)
        {
            transform.position = new Vector2(-30.12f - (transform.position.x + 77.83f), transform.position.y);
        }
    }
}
