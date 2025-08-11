using UnityEngine;

public class DestroyOnPlayerCollision : MonoBehaviour
{
    public AudioSource KeySound;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (KeySound != null) KeySound.Play();
            Destroy(gameObject);
        }
    }
}