using UnityEngine;

public class GuardDeactivatedState : GuardBaseState
{
    float duration;

    public override void EnterState(GuardStateMachine guard)
    {
        guard.IsPowered = false;
        guard.Deactivateable = false;
        duration = 10f;
        Debug.Log(guard.name + " is DEACTIVATED");
    }

    public override void UpdateState(GuardStateMachine guard)
    {
        DeactivatedTimer(guard);
    }

    private void DeactivatedTimer(GuardStateMachine guard)
    {
        if (guard.IsPowered == false)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            }
            else
            {
                duration = 0;
                guard.SetState(guard.SuspiciousState);
            }
        }
    }

}
