using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUnalertState : CameraBaseState
{
    public override void EnterState(CameraStateMachine camera)
    {
        camera.IsPowered = true;
        camera.Deactivateable = true;
        Debug.Log(camera.name + " is UNALERT");
    }

    public override void UpdateState(CameraStateMachine camera)
    {
        if (!camera.HeadSight.IntruderSearch(PlayerStateMachine.Instance.gameObject))
        {
            //scan area animation

            if (camera.IsPowered == false)
            {
                camera.SetState(camera.DeactivatedState);
            }
        }
        else
        {
            camera.playerLast = PlayerStateMachine.Instance.transform.position;
            camera.SetState(camera.SuspiciousState);
        }
    }
}
