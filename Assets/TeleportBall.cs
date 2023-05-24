
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportBall : MonoBehaviour
{
    public Vector3 teleportDestination;
    public AudioClip teleportSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
          audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource is not found, create a new one and attach it
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = teleportSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
           audioSource.Play();
           other.transform.position = teleportDestination;
        }

    }
}
