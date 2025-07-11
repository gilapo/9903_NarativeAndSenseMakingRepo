using UnityEngine;

public class TriggerSoundManager : MonoBehaviour
{
    // Assign different AudioSources for each instruction
    public AudioSource instructionA;
    public AudioSource instructionB;
    public AudioSource instructionC;

    public void TryPlayInstruction(AudioSource instructionSource)
    {
        if (!instructionSource.isPlaying)
        {
            instructionSource.Play();
        }
    }
}
