using UnityEngine;

public class Key : Item
{
    public string keyName;
    public bool destroyKey;

    public override void PickUp(GameObject player)
    {
        GameManager.Instance.numKeys++;

        Destroy(gameObject);
    }
}