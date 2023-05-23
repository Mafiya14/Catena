using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _clicksAudioSource;
    [SerializeField] private AudioSource _winLoseAudioSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip _victorySound;
    [SerializeField] private AudioClip _failureSound;

    private void OnEnable()
    {
        EventBus.OnAnyButtonClicked += PlayButtonClickSound;
        CharacterBase.OnFinishReached += PlayVictorySound;
        CharacterBase.OnGameFailed += PlayFailureSound;
    }

    private void OnDisable()
    {
        EventBus.OnAnyButtonClicked -= PlayButtonClickSound;
        CharacterBase.OnFinishReached -= PlayVictorySound;
        CharacterBase.OnGameFailed -= PlayFailureSound;
    }

    private void PlayButtonClickSound()
    {
        _clicksAudioSource.PlayOneShot(_clicksAudioSource.clip);
    }

    private void PlayVictorySound()
    {
        _winLoseAudioSource.PlayOneShot(_victorySound);
    }

    private void PlayFailureSound()
    {
        _winLoseAudioSource.PlayOneShot(_failureSound);
    }
}
