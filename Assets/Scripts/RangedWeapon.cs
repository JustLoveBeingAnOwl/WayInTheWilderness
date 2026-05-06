using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [Header("General Info")]
    public string weaponName;
    public PlayerAmmoManager ammoManager;
    public float Range;
    public int Damage;
    [Header("Ammo")]
    public int magSize;
    public int currentMag;
    public AmmoType ammoType;
    public float reloadSpeed;
    [Header("Fire Rate")]
    public bool isAutomatic;
    public float rateOfFire;
    //Animation StateMachine
    public enum State {Idle, Shoot, Shoot_Last, Reload_Empty, Reload_Tactical}
    private State currentState = State.Idle;
    protected Animator animator;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip shootSFX;
    public AudioClip magazineSFX;
    public AudioClip cockingSFX;
    void Awake()
    {
        animator = GetComponent<Animator>(); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMag = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RaycastFire()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range)){
            Debug.Log(hit.collider.gameObject.name + " was hit!");
            hit.collider.GetComponent<Creature>()?.TakeDamage(Damage);
        }
    }
    public void Shoot()
    {
        if(currentState != State.Idle)
            return;
        if(currentMag <= 0)
            return; 

        if(currentMag == 1)
        {
            currentState = State.Shoot_Last;
            animator.SetTrigger("Shoot_Last");
        } else{
            currentState = State.Shoot;
            animator.SetTrigger("Shoot");
        }
    }
    public void OnShoot()
    {
        RaycastFire();
        audioSource.PlayOneShot(shootSFX);
        currentMag--;
    }

    public void PlayMagazineSound()
    {
        audioSource.PlayOneShot(magazineSFX);
    }
    public void PlayCockingSound()
    {
        audioSource.PlayOneShot(cockingSFX);
    }
    public void Reload()
    {
        if(currentState == State.Reload_Empty || currentState == State.Reload_Tactical)
            return;

        if(currentState == State.Shoot || currentState == State.Shoot_Last)
            return;

        if(currentMag >= magSize)
            return;
        
        currentState = (currentMag == 0) ? State.Reload_Empty : State.Reload_Tactical;
        if(ammoManager.HasAmmo(ammoType))
        {
            if(State.Reload_Empty == currentState)
                animator.SetTrigger("Reload_Empty");
            if(State.Reload_Tactical == currentState)
                animator.SetTrigger("Reload");
        }
    }
    public void OnReload()
    {
        int RoundsToLoad = magSize - currentMag;
        currentMag += ammoManager.ReduceAmmoAndLoad(ammoType, RoundsToLoad);
        BecomeIdle();
    }

    public void BecomeIdle() //This is mainly for the animation event triggers.
    {
        currentState = State.Idle;
    }
    public void Holster()
    {
        gameObject.SetActive(false);
    }
    public void UnHolster()
    {
        gameObject.SetActive(true);
    }
}
