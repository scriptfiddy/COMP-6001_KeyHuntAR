using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public string Tag = "Target";
    public GameObject LVL2;
    public GameObject LVL3;
    public GameObject GameUI;
    public GameObject WinPanel;
    public GameObject LevelPresentationText2;
    public GameObject LevelPresentationText3;
    private int QuestCompleted = 0;
    private GameObject backgroundMusic;
    private GameObject ScriptAux;
    private Dictionary<Renderer, Color> targetColors = new Dictionary<Renderer, Color>();

    void Update()
    {
        if (QuestCompleted == 3) return;

        GameObject[] keys = GameObject.FindGameObjectsWithTag(Tag);

        // Change UI text object "key_info" to the number of collected keys
        GameObject keyInfo = GameObject.Find("key_info");
        if (keyInfo != null)
        {
            var text = keyInfo.GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = (5 - keys.Length) + "/5";
            }
        }

        if (keys.Length == 0)
        {
            QuestCompleted++;
            CompleteQuest();
        }

        // If quest completed == 1, color of the trees continuously and randomly
        if (QuestCompleted == 1)
        {
            foreach (GameObject leaf in GameObject.FindGameObjectsWithTag("Leafs"))
            {
                var renderer = leaf.GetComponent<Renderer>();
                var mat = renderer.material;

                if (!targetColors.ContainsKey(renderer))
                    targetColors[renderer] = new Color(Random.value, Random.value, Random.value);

                mat.color = Color.Lerp(mat.color, targetColors[renderer], Time.deltaTime * 0.5f);

                if (Vector4.Distance(mat.color, targetColors[renderer]) < 0.05f)
                    targetColors[renderer] = new Color(Random.value, Random.value, Random.value);
            }
        }
    }

    void CompleteQuest()
    {
        if (QuestCompleted == 1)
        {
            LVL2.SetActive(true);
            // Change background music to HardMusic
            backgroundMusic = GameObject.Find("BackgroundMusic");
            if (backgroundMusic != null)
            {
                var audioSource = backgroundMusic.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/HardMusic");
                    audioSource.Play();
                }
            }

            // Reproduce the sound to announce lvl2 has been reached
            ScriptAux = GameObject.Find("ScriptAux");
            AudioSource[] sources = ScriptAux.GetComponents<AudioSource>();
            sources[1].Play();

            // Change UI text object "level_info" to "LVL: 2 (Heights)"
            GameObject levelInfo = GameObject.Find("level_info");
            levelInfo.GetComponent<TextMeshProUGUI>().text = "LVL: 2 (Heights)";

            // Change UI text object "key_info" to "0/5"
            GameObject keyInfo = GameObject.Find("key_info");
            keyInfo.GetComponent<TextMeshProUGUI>().text = "0/5";

            // Enable LevelPresentationText2
            if (LevelPresentationText2 != null)
            {
                LevelPresentationText2.SetActive(true);
            }

            // Set material of every object with tag "Leafs" to "Green4"
            GameObject[] leafs = GameObject.FindGameObjectsWithTag("Leafs");
            foreach (GameObject leaf in leafs)
            {
                Renderer renderer = leaf.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = Resources.Load<Material>("Materials/Green4");
                }
            }
        }
        else if (QuestCompleted == 2)
        {
            LVL3.SetActive(true);
            // Change background music to HardMusic
            backgroundMusic = GameObject.Find("BackgroundMusic");
            if (backgroundMusic != null)
            {
                var audioSource = backgroundMusic.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.clip = Resources.Load<AudioClip>("Sounds/FinalMusic");
                    audioSource.Play();
                }
            }
            // Change UI text object "level_info" to "LVL: 3 (Timing)"
            GameObject levelInfo = GameObject.Find("level_info");
            levelInfo.GetComponent<TextMeshProUGUI>().text = "LVL: 3 (Timing)";

            // Change UI text object "key_info" to "0/5"
            GameObject keyInfo = GameObject.Find("key_info");
            keyInfo.GetComponent<TextMeshProUGUI>().text = "0/5";

            // Reproduce the sound to announce lvl3 has been reached
            ScriptAux = GameObject.Find("ScriptAux");
            AudioSource[] sources = ScriptAux.GetComponents<AudioSource>();
            sources[2].Play();

            // Enable LevelPresentationText3
            if (LevelPresentationText3 != null)
            {
                LevelPresentationText3.SetActive(true);
            }

            // Set material of every object with tag "Leafs" to "Green4"
            GameObject[] leafs = GameObject.FindGameObjectsWithTag("Leafs");
            foreach (GameObject leaf in leafs)
            {
                Renderer renderer = leaf.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = Resources.Load<Material>("Materials/Gold");
                }
            }
        }
        else if (QuestCompleted == 3)
        {
            //print console message "You have completed the quest!"
            if (GameUI != null)
            {
                GameUI.SetActive(false);
            }
            if (WinPanel != null)
            {
                WinPanel.SetActive(true);
            }
            if (backgroundMusic != null)
            {
                var audioSource = backgroundMusic.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
            }
            AudioSource[] sources = ScriptAux.GetComponents<AudioSource>();
            sources[3].Play();
        }
    }
}
