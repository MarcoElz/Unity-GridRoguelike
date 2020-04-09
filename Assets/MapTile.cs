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
}
