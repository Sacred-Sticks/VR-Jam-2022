using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Haptics : MonoBehaviour
{
    [SerializeField] private float intensity;

    private XRBaseController controller;

    private void Awake()
    {
        controller = GetComponent<XRBaseController>();
    }

    public void PlayHaptics(float duration)
    {
        controller.SendHapticImpulse(duration, intensity);
    }
}
