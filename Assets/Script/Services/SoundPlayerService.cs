using UnityEngine;

public class SoundPlayerService : ISoundPlayerService
{
    private readonly AudioSource audioSource;
    private readonly AudioClip openClip;
    private readonly AudioClip closeClip;

    public SoundPlayerService(
        AudioSource audioSource,
        AudioClip openClip,
        AudioClip closeClip)
    {
        this.audioSource = audioSource;
        this.openClip = openClip;
        this.closeClip = closeClip;
    }

    public void PlayOpenSound()
    {
        if (openClip != null)
            audioSource.PlayOneShot(openClip);
    }

    public void PlayCloseSound()
    {
        if (closeClip != null)
            audioSource.PlayOneShot(closeClip);
    }
}
