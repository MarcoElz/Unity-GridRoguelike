using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{
    public int Durability { get; private set; }

    public void Damage(int amount)
    {
        amount = amount / 2; //Las paredes tienen mas defensa:)
        Durability -= amount;
        Debug.Log("Wall was damaged. Durability: " + Durability);
    }

    public void Heal(int amount)
    {
        Debug.LogWarning("LOL, walls can not be healed.");
    }
}
