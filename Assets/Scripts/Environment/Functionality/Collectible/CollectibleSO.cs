using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleData", menuName = "SO/Collectible")]
public class CollectibleSO : ScriptableObject
{
    public string group;
    public int totalAmountOfThisGroup;
    public string displayName;
}