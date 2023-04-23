using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvisibleState : PlayerBaseState 
{
    bool timerIsRunning = true;
    float duration = 3f;

    public override void EnterState(PlayerStateMachine player)
    {
        player.isInvisible = true;
         timerIsRunning = true;
    }

    public override void UpdateState(PlayerStateMachine player)
    {
        SuspicionTimer(player);
    }

    private void SuspicionTimer(PlayerStateMachine player)
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
                player.SetState(player.GameplayState);
            }
        }
    }
}
