using UnityEngine;

public class AudioControll : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip mainSound;
    private void Awake() => audioSource.enabled = Utils.IsSoundEnabled();
    void Start()
    {
        audioSource.loop = true;
        audioSource.clip = mainSound;
        audioSource.Play();
    }

    public void ReAwakeStart()
    {
        Awake();
        Start();
    }
}
