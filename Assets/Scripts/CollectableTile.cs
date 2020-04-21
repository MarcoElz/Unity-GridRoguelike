using UnityEngine;

public class CollectableTile : GameTile
{
    [SerializeField] Item[] items;

    public override void ApplyEffects()
    {
        for(int i = 0; i < items.Length; i++)
        {
            //Aplicar effectos de cada item
            items[i].Use();
        }
        Destroy(this.gameObject);
    }
}
