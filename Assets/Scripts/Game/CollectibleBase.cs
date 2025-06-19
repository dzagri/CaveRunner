using UnityEngine;

[RequireComponent(typeof(Collider), typeof(AudioSource))]
public abstract class CollectibleBase : MonoBehaviour, ICollectible
{
    float timer;
    new AudioSource audio;
    Vector3 rotationSpeed = new(0, 90f, 0);

    readonly float bobAmplitude = 2.7f;
    readonly float bobFrequency = 2f;

    void Awake() => audio = GetComponent<AudioSource>();
    public abstract void Collect(ManageCollectibles manager);

    void Update()
    {
        Animate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            if (other.TryGetComponent<ManageCollectibles>(out var manager))
            {
                transform.GetChild(0).gameObject.SetActive(false);
                Collect(manager);
            }
            if (CompareTag("Coin"))
            {
                timer = Time.time;
                if(timer <= 2)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
    void Animate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);

        float newY = transform.position.y + Mathf.Sin(Time.time * bobFrequency * Mathf.PI * 2) * bobAmplitude * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
