using UnityEngine;

public class SpikeAnimations : MonoBehaviour
{
    Animator animator;

    void Start() => animator = GetComponentInParent<Animator>();
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
        }
    }

}
