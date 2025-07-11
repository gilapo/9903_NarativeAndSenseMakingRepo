using UnityEngine;

public class AreaSoundTrigger : MonoBehaviour
{
    public TriggerSoundManager soundManager;
    public AudioSource instructionClipToPlay;
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            soundManager.TryPlayInstruction(instructionClipToPlay);
        }
    }
}
