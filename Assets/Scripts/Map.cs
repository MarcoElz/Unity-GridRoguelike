using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject[] backgroundMapPrefab;
    [SerializeField] GameObject[] wallPrefab;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject exitPrefab;
    [SerializeField] GameObject foodPrefab;

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

        //mapTiles[0][0].AddNewTileToTheList(player.GetComponent<GameTile>());
        mapTiles[x - 1][y - 1].AddNewTileToTheList(exit.GetComponent<GameTile>());

        //Pared fija. TODO: Hacer mapa random
        GameObject wall = Instantiate(wallPrefab[0], new Vector3(2f, 2f, 0f), Quaternion.identity);
        mapTiles[2][2].AddNewTileToTheList(wall.GetComponent<GameTile>());
        //Food fijo. TODO: Hacer mapa random
        GameObject food = Instantiate(foodPrefab, new Vector3(3f, 3f, 0f), Quaternion.identity);
        mapTiles[3][3].AddNewTileToTheList(food.GetComponent<GameTile>());

        IDamageable playerDamageable = player.GetComponent<IDamageable>();
        IDamageable wallDamageable = wall.GetComponent<IDamageable>();

        IDamageable[] damageables = new IDamageable[2];
        damageables[0] = playerDamageable;
        damageables[1] = wallDamageable;

        for(int i = 0; i < damageables.Length; i++)
        {
            damageables[i].Damage(5);
        }
    }

    public bool IsTileEmpty(int x, int y)
    {
        //Si esta dentro de los limite del mapa
        if (x < 0 || x >= mapTiles.Length || y < 0 || y >= mapTiles[x].Length)
            return false;

        //Si la tile tiene un objeto que no se puede atravesar
        if (mapTiles[x][y] != null && mapTiles[x][y].HasPhysicalTile())
        {
            return false;
        }

        //Si la tile tiene algun personaje
        if(Character.IsAnyCharacterAt(x,y))
        {
            return false;
        }

        return true;
    }

    public void ApplyEffectsOnTile(int x, int y, Character characterToApplyEffect)
    {
        if (mapTiles[x][y] != null) //Existe el MapTile
        {
            mapTiles[x][y].ApplyEffectsOfTheTile(characterToApplyEffect); //Aplicar los Efectos
        } 
    }


}
