using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Name", menuName = "Roguelike/Effects/HealEffects", order = 1)]
public class HealingEffect : Effect
{
    [SerializeField] float healPoints;

    public override void Apply()
    {
        Debug.Log("Healing: " + healPoints);
    }
}
