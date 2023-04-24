using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoadingState : GameBaseState
{
    public override void EnterState(GameStateMachine game)
    {
        Time.timeScale = 1f;
        game.sceneBehaviour.NextScene();
    }

    public override void UpdateState(GameStateMachine player)
    {

    }
}
