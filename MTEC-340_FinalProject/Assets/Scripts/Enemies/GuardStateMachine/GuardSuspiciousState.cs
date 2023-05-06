using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSuspiciousState : GuardBaseState
{
    public float duration;
    public bool timerIsRunning;

    public override void EnterState(GuardStateMachine guard)
    {
        guard.EnemyMovement.agent.enabled = false;
        guard.IsPowered = true;
        guard.Deactivateable = false;
        guard.BodySight.enabled = true;
        guard.HeadSight.enabled = true;
        Debug.Log(guard.name + " is SUSPICIOUS");
        guard.gameObject.transform.LookAt(guard.playerLast);
        //Stop Head Scanning Animation
        guard.Audio.SuspiciousVO();
        duration = 5f;
        timerIsRunning = true;
    }

    public override void UpdateState(GuardStateMachine guard)
    {
        guard.IsPowered = !guard.ReactiveTarget.deactivated;
        if (guard.IsPowered == false)
        {
            guard.SetState(guard.DeactivatedState);
        }
        //guard.StartCoroutine(SuspicionCoroutine(guard));
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

    public IEnumerator SuspicionCoroutine(GuardStateMachine guard)
    {
        timerIsRunning = true;
        yield return new WaitForSeconds(duration);
        timerIsRunning = false;
        EnemySpotted(guard);
        yield return new WaitForSeconds(1);
        Debug.Log("In the routine");
    }

    private void EnemySpotted(GuardStateMachine guard)
    {
        if (!guard.HeadSight.IntruderSearch(PlayerStateMachine.Instance.gameObject) && !PlayerStateMachine.Instance.isInvisible)
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
