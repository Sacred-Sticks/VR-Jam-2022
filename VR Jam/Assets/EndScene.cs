using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] private int waitTime;

    private AudioSource audioComponent;

    private void Awake()
    {
        audioComponent = GetComponent<AudioSource>();
    }

    private IEnumerator FinishScene()
    {
        audioComponent.Play();
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }

    public void EndGame()
    {
        StartCoroutine(FinishScene());
    }
}
