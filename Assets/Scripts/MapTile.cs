using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    private List<GameTile> tiles;

    private void Awake()
    {
        tiles = new List<GameTile>();
    }

    public void AddNewTileToTheList(GameTile tile)
    {
        tiles.Add(tile);
    }

    public bool HasPhysicalTile()
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            if(tiles[i] is PhysicalTile)
            { 
                return true;
            }
        }

        return false;
    }

    public void ApplyEffectsOfTheTile(Character characterToApplyEffect)
    {
        for (int i = 0; i < tiles.Count; i++) // Iterar en cada GameTile de esta MapTile
        {
            //Aplicar el efecto de la tile (sin importar que tipo es)
            tiles[i].ApplyEffects(characterToApplyEffect);

            if (tiles[i] is CollectableTile) //Si es un CollectableTile
            {
                //Remover el collectable porque se supone que lo agarramos
                Destroy(tiles[i].gameObject);
                tiles.RemoveAt(i);
            }
        }
    }
}
