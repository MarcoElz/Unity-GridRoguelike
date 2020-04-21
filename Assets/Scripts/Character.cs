using System.Collections.Generic;
using UnityEngine;


public abstract class Character : MonoBehaviour
{
    private static List<Character> characters = new List<Character>();

    private void Awake()
    {
        characters.Add(this);
    }

    public static bool IsAnyCharacterAt(int x, int y)
    {
        for(int i = 0; i < characters.Count; i++)
        {
            if (characters[i] == null)
                continue;

            Vector3 pos = characters[i].transform.position;
            if(Mathf.RoundToInt(pos.x) == x && Mathf.RoundToInt(pos.y) == y)
            {
                return true;
            }
        }

        return false;
    }
}
