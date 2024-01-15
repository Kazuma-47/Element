using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ability", menuName = "ScriptableObjects/Abilities")]
public class Ability : ScriptableObject
{
   public enum Elements
    {
        Fire,
        Water,
        None
    };
   public Elements Element;
}
