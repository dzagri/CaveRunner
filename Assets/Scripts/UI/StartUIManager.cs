using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] TMP_Text highScoretext;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Transform[] purchaseMenus;
    [SerializeField] Material material;
    readonly int mute = -80, unmute = 0;
    bool musicActive;
    bool sfxActive;
    readonly float[] rgb = new float[3] { 1f, 1f, 1f};
    bool IsColorPurchased(string key) => PlayerPrefs.GetInt(key, 0) == 1;
    #endregion

    #region Start
    void Start()
    {
        Initialization();
    }
    void Initialization()
    {
        HighScore();
        PlayerPrefs.SetFloat("FlashlightColorR", rgb[0]);
        PlayerPrefs.SetFloat("FlashlightColorG", rgb[1]);
        PlayerPrefs.SetFloat("FlashlightColorB", rgb[2]);
        material.color = Color.red;
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
    #endregion

    #region Settings
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
    #endregion

    #region Shop
    public void CartColor(int index)
    {
        int cost = 250;
        string purchaseKey = $"CartColor_{index}";

        if (!IsColorPurchased(purchaseKey))
        {
            if (!GameManager.instance.TryPurchase(cost))
                return;

            SetColorPurchased(purchaseKey);
            PlayerPrefs.Save();
            coinsText.text = GameManager.instance.currentCoins.ToString();
        }

        Color selectedColor = index switch
        {
            0 => Color.red,
            1 => Color.blue,
            2 => Color.green,
            3 => Color.yellow,
            4 => new Color(0.5f, 0f, 0.5f),
            5 => new Color(1f, 0.5f, 0f),
            6 => new Color(1f, 0.41f, 0.71f),
            7 => new Color(0f, 1f, 1f),
            8 => Color.black,
            _ => Color.white
        };

        material.color = selectedColor;
    }

    public void FlashlightColor(int index)
    {
        int cost = 125;
        string purchaseKey = $"FlashlightColor_{index}";

        if (!IsColorPurchased(purchaseKey))
        {
            if (!GameManager.instance.TryPurchase(cost))
                return;

            SetColorPurchased(purchaseKey);
            PlayerPrefs.Save();
            coinsText.text = GameManager.instance.currentCoins.ToString();
        }

        Color selectedColor = index switch
        {
            0 => Color.red,
            1 => Color.blue,
            2 => Color.green,
            3 => Color.yellow,
            4 => new Color(0.5f, 0f, 0.5f),
            5 => new Color(1f, 0.5f, 0f),
            6 => new Color(1f, 0.41f, 0.71f),
            7 => new Color(0f, 1f, 1f),
            8 => Color.white,
            _ => Color.white
        };

        PlayerPrefs.SetFloat("FlashlightColorR", selectedColor.r);
        PlayerPrefs.SetFloat("FlashlightColorG", selectedColor.g);
        PlayerPrefs.SetFloat("FlashlightColorB", selectedColor.b);
        PlayerPrefs.SetInt("FlashlightColorIndex", index);
        PlayerPrefs.Save();
    }
    void SetColorPurchased(string key) => PlayerPrefs.SetInt(key, 1);
    #endregion
}
