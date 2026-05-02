using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoInventory : MonoBehaviour
{
    public TextMeshProUGUI pistolAmmoText;
    public TextMeshProUGUI shotgunAmmoText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAmmoInventoryBars(int pistolAmmo, int shotgunAmmo)
    {
        pistolAmmoText.text = "PSTL: " + pistolAmmo.ToString();
        shotgunAmmoText.text = "SHOT: " + shotgunAmmo.ToString();
    }
}
