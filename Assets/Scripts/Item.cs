using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public String itemName;
    public bool requireInput = false;
    public abstract void PickUp (GameObject player);
}

