using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSuspiciousState : GuardBaseState
{
    public float duration;
    public bool timerIsRunning;

    public override void EnterState(GuardStateMachine guard)
    {
        Debug.Log(guard.name + " is SUSPICIOUS");
        //Stop Head Scanning Animation
        //Play Random VO
        duration = 10f;
        timerIsRunning = true;
    }

    public override void UpdateState(GuardStateMachine guard)
    {
        SuspicionTimer(guard);
    }

    private void SuspicionTimer(GuardStateMachine guard)
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
                EnemySpotted(guard);
            }
        }
    }

    private void EnemySpotted(GuardStateMachine guard)
    {
        if (!guard.HeadSight.seenObject.CompareTag("Player"))
        {
            //Play Random "Must've been the wind..." VO
            guard.SetState(guard.UnalertState);
        }
        else
        {
            guard.SetState(guard.AlertState);
        }
    }
}
