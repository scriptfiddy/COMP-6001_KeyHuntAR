using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MusicToggleHandler : MonoBehaviour
{
    private Toggle musicToggle;
    private GameObject gameManagerObject;

    void Awake()
    {
        // Auto-assign by name
        musicToggle = GameObject.Find("MusicToggle")?.GetComponent<Toggle>();
        gameManagerObject = GameObject.Find("GameManager");

        if (musicToggle == null || gameManagerObject == null)
        {
            Debug.LogError("MusicToggle or GameManager not found.");
            return;
        }

        // Optionally set initial state from GameManager
        bool currentState = Variables.Object(gameManagerObject).Get<bool>("musicActive");
        musicToggle.isOn = currentState;

        // Subscribe to toggle change event
        musicToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (gameManagerObject != null)
        {
            Variables.Object(gameManagerObject).Set("musicActive", isOn);
        }
    }
}
