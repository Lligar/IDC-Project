using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BlockerTest : MonoBehaviour
{
    void Start()
    {
        var blocker = GetComponent<SingleNodeBlocker>();

        blocker.BlockAtCurrentPosition();
    }

    void Update()
    {
        
    }
}
