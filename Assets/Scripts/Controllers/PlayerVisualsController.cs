using UnityEngine;

public class PlayerVisualsController : MonoBehaviour 
{
    PlayerSoundController soundController;

    private void Awake() 
    {
        soundController = GetComponent<PlayerSoundController>();
    }    
}