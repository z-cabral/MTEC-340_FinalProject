using UnityEngine;

public class GuardUnalertState : GuardBaseState
{
    public override void EnterState(GuardStateMachine guard)
    {
        guard.EnemyMovement.agent.enabled = true;
        guard.IsPowered = true;
        guard.Deactivateable = true;
        Debug.Log(guard.name + " is UNALERT");
    }

    public override void UpdateState(GuardStateMachine guard)
    {
        //if (!guard.HeadSight.seenObject.TryGetComponent<MouseLook>(out MouseLook looker))
        if(!guard.HeadSight.IntruderSearch(GameBehavior.Instance.Player))
        {
            //placeholder until NavMesh Movement is fully implemented
            //guard.EnemyMovement.Wander(10);
            guard.EnemyMovement.Patrol();
            if (guard.IsPowered == false)
            {
                guard.SetState(guard.DeactivatedState);
            }
        }
        else
        {
            guard.playerLast = GameBehavior.Instance.PlayerPos.position;
            guard.SetState(guard.SuspiciousState);
        }     
    }
}
