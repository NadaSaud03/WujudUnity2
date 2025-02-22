using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public AudioClip speechClip;  // The audio clip for speech
    private AudioSource audioSource;
    public float interactDistance = 3f;  // Distance to trigger the interaction
    private bool isPlayerNear = false;

    void Start()
    {
        // Get the AudioSource component on the character
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the player is within range
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < interactDistance)
        {
            isPlayerNear = true;
        }
        else
        {
            isPlayerNear = false;
        }

        // Check for player input (e.g., pressing a key or button) to play speech
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !audioSource.isPlaying)
        {
            PlaySpeech();
        }
    }

    void PlaySpeech()
    {
        // Play the speech clip
        audioSource.PlayOneShot(speechClip);
    }

    // Optional: You can also use OnTriggerEnter for interaction when the player physically touches the character
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !audioSource.isPlaying)
        {
            PlaySpeech();
        }
    }
}
