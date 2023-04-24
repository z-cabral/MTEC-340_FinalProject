using UnityEngine;

public class GuardAlertState : GuardBaseState
{
    public override void EnterState(GuardStateMachine guard)
    {
        guard.IsPowered = true;
        guard.Deactivateable = false;
        Debug.Log(guard.name + " is ALERT");
        //Trigger Game Over
        GameStateMachine.Instance.SetState(GameStateMachine.Instance.gameOver);
    }

    public override void UpdateState(GuardStateMachine guard)
    {

    }
}
