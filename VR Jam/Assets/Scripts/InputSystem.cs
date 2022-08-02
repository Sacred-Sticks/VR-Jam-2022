using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerInputs;
    [SerializeField] private string controllerActionMap;
    [Space]
    [SerializeField] private string triggerActionName;
    [SerializeField] private string gripActionName;
    [SerializeField] private string primaryButtonName;
    [SerializeField] private string secondaryButtonName;
    [SerializeField] private string joystickName;
    [SerializeField] private string pauseButtonName;

    private InputAction triggerAction;
    private InputAction gripAction;
    private InputAction primaryAction;
    private InputAction secondaryAction;
    private InputAction joystickAction;
    private InputAction pauseAction;

    private float triggerValue;
    private float gripValue;
    private float primaryValue;
    private float secondaryValue;
    private Vector2 joystickValue;
    private float pauseValue;

    private void Awake()
    {
        var actionMap = playerInputs.FindActionMap(controllerActionMap);

        if (triggerActionName != "")
        {
            triggerAction = actionMap.FindAction(triggerActionName);
            triggerAction.performed += OnTriggerChanged;
            triggerAction.canceled += OnTriggerChanged;
            triggerAction.Enable();
        }

        if (gripActionName != "")
        {
            gripAction = actionMap.FindAction(gripActionName);
            gripAction.performed += OnGripChanged;
            gripAction.canceled += OnGripChanged;
            gripAction.Enable();
        }

        if (primaryButtonName != "")
        {
            primaryAction = actionMap.FindAction(primaryButtonName);
            if (primaryAction == null) Debug.Log("not found on " + controllerActionMap);
            primaryAction.performed += OnPrimaryChanged;
            primaryAction.canceled += OnPrimaryChanged;
            primaryAction.Enable();
        }

        if (secondaryButtonName != "")
        {
            secondaryAction = actionMap.FindAction(secondaryButtonName);
            secondaryAction.performed += OnSecondaryChanged;
            secondaryAction.canceled += OnSecondaryChanged;
            secondaryAction.Enable();
        }

        if (joystickName != "")
        {
            joystickAction = actionMap.FindAction(joystickName);
            joystickAction.performed += OnJoystickChanged;
            joystickAction.canceled += OnJoystickChanged;
            joystickAction.Enable();
        }

        if (pauseButtonName != "")
        {
            pauseAction = actionMap.FindAction(pauseButtonName);
            pauseAction.performed += OnPauseChanged;
            pauseAction.canceled += OnPauseChanged;
            pauseAction.Enable();
        }
    }

    private void OnTriggerChanged(InputAction.CallbackContext context)
    {
        triggerValue = context.ReadValue<float>();
    }

    private void OnGripChanged(InputAction.CallbackContext context)
    {
        gripValue = context.ReadValue<float>();
    }

    private void OnPrimaryChanged(InputAction.CallbackContext context)
    {
        primaryValue = context.ReadValue<float>();
    }

    private void OnSecondaryChanged(InputAction.CallbackContext context)
    {
        secondaryValue = context.ReadValue<float>();
    }

    private void OnJoystickChanged(InputAction.CallbackContext context)
    {
        joystickValue = context.ReadValue<Vector2>();
    }

    private void OnPauseChanged(InputAction.CallbackContext context)
    {
        pauseValue = context.ReadValue<float>();
    }

    public float GetTrigger()
    {
        return triggerValue;
    }

    public float GetGrip()
    {
        return gripValue;
    }

    public float GetPrimary()
    {
        return primaryValue;
    }

    public float GetSecondary()
    {
        return secondaryValue;
    }

    public Vector2 GetJoystick()
    {
        return joystickValue;
    }

    public float GetPause()
    {
        return pauseValue;
    }
}
