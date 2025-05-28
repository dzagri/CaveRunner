using UnityEngine;

public class FlashlightColor : MonoBehaviour
{
    new Light light;

    void Awake() => light = GetComponent<Light>();
    void Start()
    {
        float r = PlayerPrefs.GetFloat("FlashlightColorR");
        float g = PlayerPrefs.GetFloat("FlashlightColorG");
        float b = PlayerPrefs.GetFloat("FlashlightColorB");

        light.color = new (r, g, b);
    }
}
