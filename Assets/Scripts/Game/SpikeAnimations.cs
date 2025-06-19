using UnityEngine;

public class SpikeAnimations : MonoBehaviour
{
    Animator animator;
    new AudioSource audio;
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
            audio.Play();
        }
    }

}
