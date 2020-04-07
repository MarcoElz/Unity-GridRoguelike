using UnityEngine;

public enum TileType { Physical, Static, Collectable }

public class GameTile : MonoBehaviour
{
    [SerializeField] TileType type;

    public TileType Type { get { return type; } }
}
