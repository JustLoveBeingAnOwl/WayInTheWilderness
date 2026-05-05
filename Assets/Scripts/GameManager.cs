using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    [Header("Game Info")]
    public int MaxEnemies = 4;
    int currentEnemies;
    //public List<Key> keyInventory = new List<Key>();
    //Unused for now.
    public int numKeys = 0;
    public bool isPaused = false;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip ambientTrack;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitiateVictory()
    {
        SceneManager.LoadScene("VictoryMenu");
    }
    public void InitiateLoss()
    {
        SceneManager.LoadScene("DefeatScene");
    }
    public void PauseToggle()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            Debug.Log("Unpaused!");
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;    
            Debug.Log("Paused!");
        }
        
    }
    public void UseKeyDoor(Door door)
    {   
        // if(door.key == null)
        // {
        //     Debug.Log("Door does not need a key OR it is not set in the ditor!");
        // }
        /*else*/ if (door.IsLocked)
        {
            if(numKeys > 0)
            {
                door.IsLocked = false;
                numKeys--;
                Debug.Log("Door unlocked!");
            }
        }
        // else
        // {
        //     Debug.Log("You do not have the key or the door is unlocked.");
        // }
    }
}
