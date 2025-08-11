using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneController : MonoBehaviour
{
    private GameObject backgroundMusic;
    private GameObject gameManagerObject;
    public static SceneController instance;
    private bool lastState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        backgroundMusic = GameObject.Find("BackgroundMusic");
        gameManagerObject = GameObject.Find("GameManager");
        // Get the current musicActive state
        lastState = Variables.Object(gameManagerObject).Get<bool>("musicActive");
        backgroundMusic.SetActive(lastState);
    }

    void Update()
    {
        if (backgroundMusic == null || gameManagerObject == null) return;

        // Check for change in musicActive variable
        bool currentState = Variables.Object(gameManagerObject).Get<bool>("musicActive");

        if (currentState != lastState)
        {
            backgroundMusic.SetActive(currentState);
            lastState = currentState;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex == -1)
        {
            QuitGame();
            return;
        }
        SceneManager.LoadSceneAsync(levelIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
