using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "CreateItem")] 
public class ItemCreation : ScriptableObject
{
    [field:SerializeField] new string name;

    [field:SerializeField] public string trait { get; private set; }
    [field:SerializeField] public Material material { get; private set; }
    [field:SerializeField] public int priceModifier { get; private set; }
}
