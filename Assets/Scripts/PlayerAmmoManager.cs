using UnityEngine;

public class PlayerAmmoManager : MonoBehaviour
{
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
        int ammoReturned = 0;
        switch (ammo)
        {
            case (AmmoType.Pistol):
                if((PistolAmmo -= amount) > 0)
                {
                    ammoReturned = PistolAmmo-amount;
                    PistolAmmo -= amount;
                }
                else
                {
                    ammoReturned = PistolAmmo;
                    PistolAmmo = 0;
                }
                return ammoReturned;
            case (AmmoType.Revolver):
                if((RevolverAmmo -= amount) > 0)
                {
                    ammoReturned = RevolverAmmo-amount;
                    RevolverAmmo -= amount;
                }
                else if (RevolverAmmo > 0)
                {
                    ammoReturned = RevolverAmmo;
                    RevolverAmmo = 0;
                }
                return ammoReturned;
            case (AmmoType.RifleFull):
                if((RevolverAmmo -= amount) > 0)
                {
                    
                }
                return ammoReturned;
            default:
                //The only place this function is called is in gun's scripts, but this is a default fallback to return 0 anyway.
                return ammoReturned;
        }
    }
}
