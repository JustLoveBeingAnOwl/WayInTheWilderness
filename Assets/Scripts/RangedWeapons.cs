using UnityEngine;

public class RangedWeapons : MonoBehaviour
{
    [Header("General Info")]
    public string weaponName;
    
    PlayerAmmoManager ammoManager;
    public float Range;
    [Header("Ammo")]
    public int magSize;
    public int currentMag;
    public AmmoType ammoType;
    [Header("Fire Rate")]
    public bool isAutomatic;

    public float rateOfFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMag = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (currentMag > 0)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
        }
        else
        {
            return;
        }
    }
}
