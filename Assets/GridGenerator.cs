using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] GameObject[] backgroundPrefabs;
    GameObject[][] backgroundGrid;

    private void Start()
    {
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
                backgroundGrid[i][j] = Instantiate(backgroundPrefabs[random], position, Quaternion.identity);
            }
        }


    }

}
