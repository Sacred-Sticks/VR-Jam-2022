using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcholocationController : MonoBehaviour
{
    [SerializeField] private bool playingAudio;

    private PlayAudio playAudio;
    private EchoLocation echoLocation;

    private void Awake()
    {
        playAudio = GetComponentInChildren<PlayAudio>();
        echoLocation = GetComponentInChildren<EchoLocation>();
    }

    void Update()
    {
        if (playingAudio)
        {
            playAudio.AudioPlayer();
            echoLocation.CreateVisuals();
            playingAudio = false;
        }
    }
}
