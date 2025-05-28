using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.playerDamage = true;
            gameObject.SetActive(false);
        }
    }
}
