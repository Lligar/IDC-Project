using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo
{
    public int maxHealth;
    public int currentHealth;
    public CharacterType characterType;

    public enum CharacterType
    {
        Player,
        Enemy
    }
}
