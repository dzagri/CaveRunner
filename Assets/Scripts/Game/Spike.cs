using UnityEngine;

public class Spike : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.playerDamage = true;
        }
    }

}
