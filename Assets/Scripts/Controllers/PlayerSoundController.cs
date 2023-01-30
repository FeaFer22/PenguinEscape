using UnityEngine;

public class PlayerSoundController : MonoBehaviour 
{
    [SerializeField] private AudioClip[] _penguinQuacks;
    private AudioSource _audioSource;
    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void Quack()
    {
        AudioClip clip = _penguinQuacks[UnityEngine.Random.Range(0, _penguinQuacks.Length)];
        if(!_audioSource.isPlaying) 
        {
            _audioSource.PlayOneShot(clip);  
        }
    }
}