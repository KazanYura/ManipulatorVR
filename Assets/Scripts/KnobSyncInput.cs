using UnityEngine;

public class KnobSyncInput : MonoBehaviour
{
    public RobotController robotController;
    public PincherController gripper;

    public Transform knob0;
    public Transform knob1;
    public Transform knob2;
    public Transform knob3;
    public Transform knob4;
    public Transform knob5;

    void Update()
    {
        if (robotController == null)
            return;

        SyncJointToKnob(0, knob0);
        SyncJointToKnob(1, knob1);
        SyncJointToKnob(2, knob2);
        SyncJointToKnob(3, knob3);
        SyncJointToKnob(4, knob4);
        SyncJointToKnob(5, knob5);
    }

    void SyncJointToKnob(int jointIndex, Transform knob)
    {
        if (knob == null || jointIndex >= robotController.joints.Length)
            return;

        float targetAngle = knob.localEulerAngles.y;
        if (targetAngle > 180f) targetAngle -= 360f;

        GameObject jointObj = robotController.joints[jointIndex].robotPart;
        var jointController = jointObj.GetComponent<ArticulationJointController>();
        jointController.RotateTo(targetAngle);
    }

    // Викликаються через UnityEvents або VR кнопки
    public void OpenGripper()
    {
            gripper.grip = 3.0f;
            gripper.gripState = GripState.Fixed;
    }

    public void CloseGripper()
    {
            gripper.grip = -3.0f;
            gripper.gripState = GripState.Fixed;
}
}
