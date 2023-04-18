using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUnalertState : CameraBaseState
{
    public override void EnterState(CameraStateMachine camera)
    {
        Debug.Log(camera.name + " is UNALERT");
    }

    public override void UpdateState(CameraStateMachine camera)
    {
        if (!camera.HeadSight.seenObject.CompareTag("Player"))
        {
            //placeholder until NavMesh Movement is fully implemented
            //camera.EnemyMovement.Wander(10);
        }
        else
        {
            camera.SetState(camera.SuspiciousState);
        }
    }
}
