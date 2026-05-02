using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player player;
    public PlayerAmmoManager playerAmmoManager;
    public HealthBar healthBar;
    public AmmoBar ammoBar;
    public AmmoInventory ammoInventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealthBar(player.CurrentHealth, player.MaxHealth);
        ammoBar.SetAmmoBar(player.currentGun);
        ammoInventory.SetAmmoInventoryBars(playerAmmoManager.PistolAmmo, playerAmmoManager.ShotgunAmmo);
    }
}
