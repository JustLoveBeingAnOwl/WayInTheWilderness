using UnityEngine;

public class AmmoPickup : Item
{
    public AmmoType ammoType;
    public int amount = 1; // do not go under 1!
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AmmoType getAmmoType(){
        return ammoType;
    }
    public override void PickUp(GameObject player)
    {
        player.GetComponent<PlayerAmmoManager>().AddAmmo(ammoType, amount);

        Destroy(gameObject);
    }
}
