using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    private CharacterController playerController;
    private Vector3 lastPlatformPosition;

    private void Start()
    {
        lastPlatformPosition = transform.position;
    }

    private void Update()
    {
        if (playerController != null)
        {
            Vector3 delta = transform.position - lastPlatformPosition;
            playerController.Move(delta);
        }

        lastPlatformPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = null;
        }
    }
}
