using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider), typeof(AudioSource))]
public abstract class CollectibleBase : MonoBehaviour, ICollectible
{
    float timer;
    new AudioSource audio;

    void Awake() => audio = GetComponent<AudioSource>();
    public abstract void Collect(ManageCollectibles manager);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<ManageCollectibles>(out var manager))
            {
                audio.Play();
                Collect(manager);
                StartCoroutine(DisableAfterAudio());
            }
        }
        if (CompareTag("Coin") && other.CompareTag("MagnetArea"))
        {
            timer = Time.time;
            if(timer >= 2)
            {
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator DisableAfterAudio()
    {
        yield return new WaitForSeconds(audio.clip.length);
        gameObject.SetActive(false);
    }

}
