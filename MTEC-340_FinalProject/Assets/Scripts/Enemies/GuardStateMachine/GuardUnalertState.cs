using UnityEngine;

public class GuardUnalertState : GuardBaseState
{
    public override void EnterState(GuardStateMachine guard)
    {
        guard.IsPowered = true;
        guard.Deactivateable = true;
        Debug.Log(guard.name + " is UNALERT");
        guard.EnemyMovement.agent.enabled = true;
        guard.Audio.UnsuspiciousVO();
    }

    public override void UpdateState(GuardStateMachine guard)
    {
        guard.Audio.SearchingVO();
        //if (!guard.HeadSight.seenObject.TryGetComponent<MouseLook>(out MouseLook looker))
        if(!guard.HeadSight.IntruderSearch(PlayerStateMachine.Instance.gameObject))
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
            guard.playerLast = PlayerStateMachine.Instance.transform.position;
            guard.SetState(guard.SuspiciousState);
        }     
    }
}
