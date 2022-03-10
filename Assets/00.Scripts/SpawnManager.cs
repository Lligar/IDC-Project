using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pfEnemy;

    public void SpawnEnemy()
    {
        Transform tfEnemy = Instantiate(pfEnemy).transform;
        tfEnemy.position = new Vector3(5f, 0f, 0f);
    }
}
