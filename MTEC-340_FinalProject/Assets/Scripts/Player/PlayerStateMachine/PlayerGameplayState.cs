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
        //player.mouseHead.Look();
        //player.mouseBody.Look();

        player.fpsInput.PlayerMovement();
        //player.utils.detectRays();
        if (player.isInvisible)
        {
            player.SetState(player.InvisibleState);
        }
    }
}
