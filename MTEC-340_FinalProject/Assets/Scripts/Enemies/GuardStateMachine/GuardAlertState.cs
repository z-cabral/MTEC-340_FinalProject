using UnityEngine;

public class GuardAlertState : GuardBaseState
{
    public override void EnterState(GuardStateMachine guard)
    {
        Debug.Log(guard.name + " is ALERT");
        //Trigger Game Over
    }

    public override void UpdateState(GuardStateMachine guard)
    {

    }
}
