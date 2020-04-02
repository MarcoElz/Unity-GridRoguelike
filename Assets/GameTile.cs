using UnityEngine;

public enum TileType { Physical, Static, Collectable }

public class GameTile : MonoBehaviour
{
    [SerializeField] TileType type;

}
