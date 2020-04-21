using UnityEngine;

[CreateAssetMenu(fileName = "Item_Name", menuName = "Roguelike/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string description;

    [SerializeField] Effect[] effects;

    public void Use()
    {
        for(int i = 0; i < effects.Length; i++)
        {
            effects[i].Apply();
        }
    }
}
