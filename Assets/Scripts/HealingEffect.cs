using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Name", menuName = "Roguelike/Effects/HealEffects", order = 1)]
public class HealingEffect : Effect
{
    [SerializeField] int healPoints;

    public override void Apply(Character characterAppliedTo)
    {
        if(characterAppliedTo is Player)
            ((Player)characterAppliedTo).Heal(healPoints);
    }
}
