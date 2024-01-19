using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Abilities")]
public class Ability : ScriptableObject
{
    public Elements Element;
    public Sprite Icon;
}
