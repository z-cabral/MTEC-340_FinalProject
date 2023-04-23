using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameplayState : PlayerBaseState 
{
    public override void EnterState(PlayerStateMachine player)
    {
        player.isInvisible = false;
    }

    public override void UpdateState(PlayerStateMachine player)
    {
        if (player.isInvisible)
        {
            player.SetState(player.InvisibleState);
        }
    }
}
