using UnityEngine;
using System.Collections.Generic;

public class PlayerAmmoManager : MonoBehaviour
{
    [Header("Max per Type")]
    public int MaxPistol = 100;
    public int MaxRevolver = 60;
    public int MaxRifleFull = 70;
    public int MaxRifleIntermediate = 120;
    public int MaxShotgun = 80;
    public int MaxSMG = 150;
    [Header("Ammo Counts")]
    public int PistolAmmo = 28;
    public int RevolverAmmo = 0;
    public int RifleFullAmmo = 0;
    public int RifleIntermediateAmmo = 0;
    public int ShotgunAmmo = 0;
    public int SubmachineGunAmmo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int ReduceAmmoAndLoad(AmmoType ammo, int amount)
    {
        Debug.Log(amount+" is the amount given");
        int ammoReturned = 0;
        switch (ammo)
        {
            case (AmmoType.Pistol):
                if((PistolAmmo - amount) > 0)
                {
                    ammoReturned = amount;
                    PistolAmmo -= amount;
                }
                else
                {
                    ammoReturned = PistolAmmo;
                    PistolAmmo = 0;
                }
                Debug.Log(ammoReturned+" is the amount to return");
                return ammoReturned;
            default:
                //The only place this function is called is in gun's scripts, but this is a default fallback to return 0 anyway.
                return ammoReturned;
        }
    }
    public void AddAmmo(AmmoType ammo, int amount)
    {
        switch (ammo)
        {
            case(AmmoType.Pistol):
                if ((amount+PistolAmmo) <= MaxPistol)
                {
                    PistolAmmo = MaxPistol;
                    return;
                }
                PistolAmmo += amount;
                return;
        }
    }
    
    public bool HasAmmo(AmmoType ammo)
    {
        switch (ammo)
        {
            case(AmmoType.Pistol):
                if(PistolAmmo > 0)
                    return true;
                return false;
            case(AmmoType.Shotgun):
                if(ShotgunAmmo > 0)
                    return true;
                return false;
        }
        return false;
    }
}
