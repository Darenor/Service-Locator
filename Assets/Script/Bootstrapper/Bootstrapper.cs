using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;
    [SerializeField] private SaveModeService saveMode;

    public static IService Services { get; private set; }

    public static Score Score { get; private set; }

    private void Awake()
    {
        
        Score = new Score();

        Services = new ServiceLocator(
            audioSource,
            openClip,
            closeClip,
            Score,
            saveMode
            );
    }
}
