using UnityEngine;

public class CollectableTile : GameTile
{
    [SerializeField] Item[] items;

    public override void ApplyEffects(Character character)
    {
        for(int i = 0; i < items.Length; i++)
        {
            //Aplicar effectos de cada item
            items[i].Use(character);
        }
    }
}
