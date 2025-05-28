using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text highScoretext;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Transform[] purchaseMenus;
    [SerializeField] Material material;
    readonly int mute = -80, unmute = 0;
    bool musicActive;
    bool sfxActive;
    readonly float[] rgb = new float[3] { 1f, 1f, 1f};
    void Start()
    {
        HighScore();
    }

    void HighScore()
    {
        highScoretext.text = Mathf.FloorToInt(GameManager.instance.highScore).ToString();
        coinsText.text = Mathf.FloorToInt(GameManager.instance.currentCoins).ToString();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Quit()
    {
        if(Application.isPlaying)
        {
            Application.Quit();
        }
    }

    public void TargetFPS(int amount)
    {
        Application.targetFrameRate = amount;
    }

    public void Quality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void Music()
    {
        if (musicActive)
        {
            audioMixer.SetFloat("MusicVolume", unmute);
            musicActive = false;
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", mute);
            musicActive = true;
        }
    }
    public void SFX()
    {
        if (sfxActive)
        {
            audioMixer.SetFloat("SFXVolume", unmute);
            sfxActive = false;
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", mute);
            sfxActive = true;
        }
    }

    public void CartColor(int index)
    {
        int cost = 50;
        if (GameManager.instance.TryPurchase(cost))
        {
            switch (index)
            {
                case 0: material.color = Color.red; break;
                case 1: material.color = Color.blue; break;
                case 2: material.color = Color.green; break;
                case 3: material.color = Color.yellow; break;
                case 4: material.color = new(0.5f, 0f, 0.5f); break;
                case 5: material.color = new(1f, 0.5f, 0f); break;
                case 6: material.color = new(1f, 0.41f, 0.71f); break;
                case 7: material.color = new(0f, 1f, 1f); break;
                case 8: material.color = Color.black; break;
            }
            coinsText.text = GameManager.instance.currentCoins.ToString();
        }
    }

    public void FlashlightColor(int index)
    {
        int cost = 25;
        if(GameManager.instance.TryPurchase(cost))
        {
            switch(index)
            {
                case 0:
                    rgb[0] = 1f;
                    rgb[1] = 0f;
                    rgb[2] = 0f;
                    break;
                case 1:
                    rgb[0] = Color.blue.r;
                    rgb[1] = Color.blue.g;
                    rgb[2] = Color.blue.b;
                    break;
                case 2:
                    rgb[0] = Color.green.r;
                    rgb[1] = Color.green.g;
                    rgb[2] = Color.green.b;
                    break;
                case 3:
                    rgb[0] = Color.yellow.r;
                    rgb[1] = Color.yellow.g;
                    rgb[2] = Color.yellow.b;
                    break;
                case 4:
                    rgb[0] = 0.5f;
                    rgb[1] = 0f;
                    rgb[2] = 0.5f;
                    break;
                case 5:
                    rgb[0] = 1f;
                    rgb[1] = 0.5f;
                    rgb[2] = 0f;
                    break;
                case 6:
                    rgb[0] = 1f;
                    rgb[1] = 0.41f;
                    rgb[2] = 0.71f;
                    break;
                case 7:
                    rgb[0] = 0f;
                    rgb[1] = 1f;
                    rgb[2] = 1f;
                    break;
                case 8:
                    rgb[0] = Color.white.r;
                    rgb[1] = Color.white.g;
                    rgb[2] = Color.white.b;
                    break;
            }
            PlayerPrefs.SetFloat("FlashlightColorR", rgb[0]);
            PlayerPrefs.SetFloat("FlashlightColorG", rgb[1]);
            PlayerPrefs.SetFloat("FlashlightColorB", rgb[2]);
        }
    }
}
