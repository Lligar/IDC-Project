using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public string attackSequence;
    public int maxAP;
    public int currentAP;

    private void Start()
    {
        maxAP = 7;
        currentAP = maxAP;
        attackSequence = null;
    }

    public void ExcecuteSequence()
    {

    }
}
