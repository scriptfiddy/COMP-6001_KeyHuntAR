using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject objectToRotate;
    public float rotationSpeed = 7.5f; // degrees per second

    public void RotateLeft()
    {
        if (objectToRotate != null)
        {
            GameObject playerArmature = GameObject.Find("PlayerArmature");
            var characterController = playerArmature.GetComponent<CharacterController>();
            characterController.enabled = false;
            objectToRotate.transform.Rotate(Vector3.up, -rotationSpeed);
            characterController.enabled = true;
        }
    }

    public void RotateRight()
    {
        if (objectToRotate != null)
        {
            GameObject playerArmature = GameObject.Find("PlayerArmature");
            var characterController = playerArmature.GetComponent<CharacterController>();
            characterController.enabled = false;
            objectToRotate.transform.Rotate(Vector3.up, rotationSpeed);
            characterController.enabled = true;
        }
    }
}
