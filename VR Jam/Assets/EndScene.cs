using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] private int waitTime;

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public IEnumerator FinishScene()
    {
        audio.Play();
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }
}
