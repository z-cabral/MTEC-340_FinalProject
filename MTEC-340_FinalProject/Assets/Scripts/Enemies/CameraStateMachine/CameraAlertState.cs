using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAlertState : CameraBaseState
{
    public override void EnterState(CameraStateMachine camera)
    {
        camera.IsPowered = true;
        camera.Deactivateable = false;
        camera.Audio.FoundVO();
        Debug.Log(camera.name + " is ALERT");
        //Trigger Game Over
        GameStateMachine.Instance.SetState(GameStateMachine.Instance.gameOver);
    }

    public override void UpdateState(CameraStateMachine camera)
    {

    }
}