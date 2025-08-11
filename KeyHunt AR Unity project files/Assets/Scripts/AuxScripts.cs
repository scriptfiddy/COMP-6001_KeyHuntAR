using UnityEngine;
using Unity.VisualScripting; // To access Variables

public class AuxScripts : MonoBehaviour
{
    private AudioSource[] audioSources;

    void Awake()
    {
        // Cache all AudioSources when the object is initialized
        audioSources = GetComponents<AudioSource>();
    }

    // Callable function
    public void Play_Lvl1_Sound()
    {
        bool gameStarted = Variables.Object(gameObject).Get<bool>("gameStarted");

        if (!gameStarted && audioSources.Length > 0)
        {
            audioSources[0].Play();
            Variables.Object(gameObject).Set("gameStarted", true);
        }
    }

    // Callable function to destroy all the keys in the scene
    public void DestroyAllKeys()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject key in keys)
        {
            Destroy(key);
        }
    }
}
