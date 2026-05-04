using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaxEnemies = 4;
    int currentEnemies;
    public static GameManager Instance;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip ambientTrack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
