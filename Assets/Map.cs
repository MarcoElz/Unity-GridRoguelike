using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject[] backgroundMapPrefab;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject exitPrefab;

    MapTile[][] mapTiles;

    private GameObject grid;

    private void Start()
    {
        grid = new GameObject("Grid");
        GenerateGrid(5,5);
    }

    public void GenerateGrid(int x, int y)
    {
        //Inicializamos la matriz del escenario
        mapTiles = new MapTile[x][];
        for(int i = 0; i < x; i++)
        {
            mapTiles[i] = new MapTile[y];
        }

        //Instanciar el background
        for(int i = 0; i < mapTiles.Length; i++)
        {
            for (int j = 0; j < mapTiles[i].Length; j++)
            {
                int random = Random.Range(0, backgroundMapPrefab.Length);
                Vector2 position = new Vector2(i, j);
                GameObject mapGo = Instantiate(backgroundMapPrefab[random], position, Quaternion.identity, grid.transform);
                mapGo.name = "Background["+i+"]["+j+"]";
                mapTiles[i][j] = mapGo.GetComponent<MapTile>();
            }
        }

        //Spawn Player & Exit
        GameObject player = Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        GameObject exit =  Instantiate(exitPrefab, new Vector3(x-1f, y-1f, 0f), Quaternion.identity);

        mapTiles[0][0].AddNewTileToTheList(player.GetComponent<GameTile>());
        mapTiles[x - 1][y - 1].AddNewTileToTheList(exit.GetComponent<GameTile>());
    }

    public bool IsTileEmpty(int x, int y)
    {
        if (x < 0 || x >= mapTiles.Length || y < 0 || y >= mapTiles[x].Length)
            return false;

        return true;
    }

}
