using UnityEngine;

public class WorldTile : GameTile
{
    [SerializeField] Effect[] effects;

    public override void ApplyEffects(Character characterToApplyEffect)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Apply(characterToApplyEffect);
        }
    }

}
