using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseGrab : MonoBehaviour
{
    [SerializeField] private Transform unlockingAnchor;
    [SerializeField] private InputSystem leftInput;
    [SerializeField] private InputSystem rightInput;
    [Space]
    [SerializeField] private float deadzone;

    private ConfigurableJoint leftJoint = null;
    private ConfigurableJoint rightJoint = null;
    private Vector3 unlockAnchor;

    private bool leftTrigger;
    private bool rightTrigger;
    private bool prevLeft;
    private bool prevRight;
    private bool rightChanged;
    private bool leftChanged;

    private void Update()
    {
        AlternateJointStatus();
    }

    private void GetInput()
    {
        prevRight = rightTrigger;
        prevLeft = leftTrigger;

        if (rightInput.GetTrigger() > deadzone) rightTrigger = true;
        else rightTrigger = false;
        if (leftInput.GetTrigger() > deadzone) leftTrigger = true;
        else leftTrigger = false;

        if (rightTrigger != prevRight) rightChanged = true;
        else rightChanged = false;
        if (leftTrigger != prevLeft) leftChanged = true;
        else leftChanged = false;
    }

    private void LockGrab(ConfigurableJoint joint)
    {
        joint.autoConfigureConnectedAnchor = true;
        joint.yMotion = ConfigurableJointMotion.Locked;
    }

    private void UnlockGrab(ConfigurableJoint joint)
    {
        unlockAnchor = new Vector3(joint.connectedAnchor.x, unlockingAnchor.localPosition.y, joint.connectedAnchor.z);
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = unlockAnchor;
        joint.yMotion = ConfigurableJointMotion.Limited;
    }

    private void AlternateJointStatus()
    {
        GetInput();
        AssignJoint();

        if (rightJoint != null)
            if (rightChanged)
            {
                if (rightTrigger) UnlockGrab(rightJoint);
                else LockGrab(rightJoint);
            }
        if (leftJoint != null)
            if (leftChanged)
            {
                if (leftTrigger) UnlockGrab(leftJoint);
                else LockGrab(leftJoint);
            }
    }

    public void AssignJoint()
    {
        ConfigurableJoint[] joints = GetComponents<ConfigurableJoint>();

        foreach (ConfigurableJoint j in joints)
        {
            if (j.connectedBody.gameObject == leftInput.gameObject) leftJoint = j;
            else rightJoint = j;
        }
    }
}
