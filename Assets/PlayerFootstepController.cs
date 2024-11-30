using UnityEngine;

public class PlayerFootstepController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float pitchVariance = .2f;

    private void Footstep()
    {
        if(audioSource.isPlaying || !audioSource.isActiveAndEnabled) {
            return;
        }

        audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);
        audioSource.Play();
    }
}
