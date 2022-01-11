using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BlockerPathTest : MonoBehaviour
{
    public BlockManager blockManager;
    public List<SingleNodeBlocker> obstacles;
    public Transform target;

    BlockManager.TraversalProvider traversalProvider;

    void Start()
    {
        // Create a traversal provider which says that a path should be blocked by all the SingleNodeBlockers in the obstacles array
        traversalProvider = new BlockManager.TraversalProvider(blockManager, BlockManager.BlockMode.OnlySelector, obstacles);
    }

    void Update()
    {

    }
}
