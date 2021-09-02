using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/StoreItems", order = 1)]
public class Item : ScriptableObject
{
    public string name;
    public int price;
    public int baseRestockFrequency;
}
