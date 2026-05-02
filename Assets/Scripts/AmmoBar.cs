using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoBar : MonoBehaviour
{
    public TextMeshProUGUI ammoText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAmmoBar(RangedWeapon currentWeapon)
    {
        ammoText.text = currentWeapon.weaponName + "\n" + "Magazine: "+
        currentWeapon.currentMag.ToString() + " / " +currentWeapon.magSize.ToString();
    }
}
