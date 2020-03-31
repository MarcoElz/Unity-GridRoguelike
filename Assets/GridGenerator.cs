using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] backgroundPrefabs;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject exitPrefab;

    GameObject[][] backgroundGrid;
    private GameObject grid;

    private void Start()
    {
        grid = new GameObject("Grid");
        GenerateGrid(5,5);
    }

    public void GenerateGrid(int x, int y)
    {
        //Inicializamos la matriz del escenario
        backgroundGrid = new GameObject[x][];
        for(int i = 0; i < x; i++)
        {
            backgroundGrid[i] = new GameObject[y];
        }

        //Instanciar el background
        for(int i = 0; i < backgroundGrid.Length; i++)
        {
            for (int j = 0; j < backgroundGrid[i].Length; j++)
            {
                int random = Random.Range(0, backgroundPrefabs.Length);
                Vector2 position = new Vector2(i, j);
                backgroundGrid[i][j] = Instantiate(backgroundPrefabs[random], position, Quaternion.identity, grid.transform);
                backgroundGrid[i][j].name = "Background["+i+"]["+j+"]";
            }
        }

        //Spawn Player & Exit
        Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(exitPrefab, new Vector3(x-1f, y-1f, 0f), Quaternion.identity);
    }

    public bool IsTileEmpty(int x, int y)
    {
        if (x < 0 || x >= backgroundGrid.Length || y < 0 || y >= backgroundGrid[x].Length)
            return false;

        return true;
    }

}
