using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Name", menuName = "Roguelike/Effects/WinEffect", order = 1)]
public class WinEffect : Effect
{
    public override void Apply()
    {
        Debug.Log("You win!");
    }
}
