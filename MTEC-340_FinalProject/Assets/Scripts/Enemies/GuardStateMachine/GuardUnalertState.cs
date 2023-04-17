using UnityEngine;

public class GuardUnalertState : GuardBaseState
{
    public override void EnterState(GuardStateMachine guard)
    {
        Debug.Log(guard.name + " is UNALERT");
    }

    public override void UpdateState(GuardStateMachine guard)
    {

        if (!guard.HeadSight.seenObject.CompareTag("Player"))
        {
            //placeholder until NavMesh Movement is fully implemented
            guard.EnemyMovement.Wander(10);
        }
        else
        {
            guard.SetState(guard.SuspiciousState);
        }     
    }
}
