using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerInputs;
    [SerializeField] private string leftControllerActionMap;
    [SerializeField] private string rightControllerActionMap;
    [Space]
    [SerializeField] private string triggerActionName;
    [SerializeField] private string gripActionName;
    [SerializeField] private string primaryButtonName;
    [SerializeField] private string secondaryButtonName;
    [SerializeField] private string joystickName;
    [SerializeField] private string pauseButtonName;

    private void Awake()
    {
        var actionMap = playerInputs.FindActionMap(leftControllerActionMap);
    }
}
