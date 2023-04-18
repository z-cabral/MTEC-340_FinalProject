using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSuspiciousState : CameraBaseState
{
    public float duration;
    public bool timerIsRunning;

    public override void EnterState(CameraStateMachine camera)
    {
        Debug.Log(camera.name + " is SUSPICIOUS");
        //Random VO
        duration = 10f;
        timerIsRunning = true;
    }

    public override void UpdateState(CameraStateMachine camera)
    {
        SuspicionTimer(camera);
    }

    private void SuspicionTimer(CameraStateMachine camera)
    {
        if (timerIsRunning)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                duration = 0;
                timerIsRunning = false;
                EnemySpotted(camera);
            }
        }
    }

    public IEnumerator SuspicionCoroutine(CameraStateMachine camera)
    {
        timerIsRunning = true;
        yield return new WaitForSeconds(duration);
        timerIsRunning = false;
        EnemySpotted(camera);
    }

    private void EnemySpotted(CameraStateMachine camera)
    {
        if (!camera.HeadSight.seenObject.CompareTag("Player"))
        {
            //Play Random "Must've been the wind..." VO
            camera.SetState(camera.UnalertState);
        }
        else
        {
            camera.SetState(camera.AlertState);
        }
    }
}
