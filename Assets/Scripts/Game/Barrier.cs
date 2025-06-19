using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Barrier : MonoBehaviour
{
    new AudioSource audio;

    void Awake() => audio = GetComponent<AudioSource>();
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.playerDamage = true;
            transform.GetChild(0).gameObject.SetActive(false);
            audio.Play();
        }
    }
}
