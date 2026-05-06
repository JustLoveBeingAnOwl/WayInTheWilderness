using System;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General Stats")]
    public int MaxHealth = 20;
    public int CurrentHealth = 20;
    public float Speed = 10f;
    [Header("Inventory")]
    public bool inRanged = true;
    public bool inMelee = false;
    public RangedWeapon currentGun; 
    [Header("Components")]
    CharacterController cc;
    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inRanged)
        {
            currentGun.UnHolster();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            GameManager.Instance.InitiateLoss();
        }
    }

    public void Move(Vector3 direction)
    {
        if(direction == Vector3.zero)
        {
            return;
        }
        direction = direction.normalized;

        cc.Move(direction*Speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            item.PickUp(gameObject);
        }
    }
    public void RotateCreatureForCamera(Transform cameraTransform)
    {
        transform.rotation = cameraTransform.rotation;
    }

    public void FireWeapon()
    {
        currentGun.Shoot();
    }
    public void ReloadWeapon()
    {
        currentGun.Reload();
    }
    public void SwitchToPistol()
    {
        inRanged = true;
        inMelee = false;


        currentGun.UnHolster();
    }
    public void SwitchToKnife()
    {
        inRanged = false;
        inMelee = true;

        currentGun.Holster();
    }
    public void TakeDamage(int dam)
    {
        Debug.Log("Critter took damage!");
        CurrentHealth -= dam;
    }
}
