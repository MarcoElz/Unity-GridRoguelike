using UnityEngine;

public class Player : Character, IDamageable
{
    public int HP { get; set; }

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
        Map map = FindObjectOfType<Map>();
        if (map != null) 
        {
            int finalXPosition = Mathf.RoundToInt(transform.position.x + x);
            int finalYPosition = Mathf.RoundToInt(transform.position.y + y);
            if (map.IsTileEmpty(finalXPosition, finalYPosition))
            {
                //Aplicar Movimiento
                Vector3 direction = new Vector3(x, y, 0f);
                transform.position += direction;

                //Aplica efectos del tile
                map.ApplyEffectsOnTile(finalXPosition, finalYPosition);
            }
        }
    }

    public void Damage(int amount)
    {
        HP -= amount;
        Debug.Log("Player was damaged. HP: " + HP);
    }

    public void Heal(int amount)
    {
        HP += amount;
        Debug.Log("Player was healed. HP: " + HP);
    }
}
