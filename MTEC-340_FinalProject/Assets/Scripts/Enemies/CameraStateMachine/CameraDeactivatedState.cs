using UnityEngine;

public class CameraDeactivatedState : CameraBaseState
{
    float duration;

    public override void EnterState(CameraStateMachine camera)
    {
        camera.IsPowered = false;
        camera.Deactivateable = false;
        duration = 10f;
        Debug.Log(camera.name + " is DEACTIVATED");
    }

    public override void UpdateState(CameraStateMachine camera)
    {
        DeactivatedTimer(camera);
    }

    private void DeactivatedTimer(CameraStateMachine camera)
    {
        if (camera.IsPowered == false)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                duration = 0;
                camera.SetState(camera.SuspiciousState);
            }
        }
    }

}
