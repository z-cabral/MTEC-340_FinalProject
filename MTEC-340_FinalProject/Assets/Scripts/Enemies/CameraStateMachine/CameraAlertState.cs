using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAlertState : CameraBaseState
{
    public override void EnterState(CameraStateMachine camera)
    {
        Debug.Log(camera.name + " is ALERT");
        //Trigger Game Over
    }

    public override void UpdateState(CameraStateMachine camera)
    {

    }
}