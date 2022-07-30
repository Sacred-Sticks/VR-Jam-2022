using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{
    private PlayAudio playAudio;
    private EchoLocation echoLocation;

    private void Awake()
    {
        playAudio = GetComponentInChildren<PlayAudio>();
        echoLocation = GetComponentInChildren<EchoLocation>();
    }

    public void Pulse()
    {
        playAudio.AudioPlayer();
        echoLocation.CreateVisuals();
    }
}
