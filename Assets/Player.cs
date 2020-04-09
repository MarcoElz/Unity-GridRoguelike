using UnityEngine;

public class Player : Character
{

    private void Update()
    {
        int x = 0;
        int y = 0;

        if(Input.GetKeyDown(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            y = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            y = -1;
        }

        if (x != 0 || y != 0)
        {          
            Move(x,y);
        }

        
    }

    private void Move(int x, int y)
    {
        //TODO:Clean code
        if(FindObjectOfType<Map>().IsTileEmpty((int)(transform.position.x + x), (int)(transform.position.y + y)))
        {
            Vector3 direction = new Vector3(x, y, 0f);
            transform.position += direction;

            //Hay algo en mi Tile?
            //SI
              //Que hay?
                // Item/Collectable - Lo tomamos
                // CharcoDeVeneno/Static - Nos hace daño

            //NO
              //Pues no pasa nada
        }
    }
}
