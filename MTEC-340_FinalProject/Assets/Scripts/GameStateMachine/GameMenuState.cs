using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameBaseState
{
    public override void EnterState(GameStateMachine game)
    {
        //game.sceneBehaviour.LoadScene(0);
        Time.timeScale = 0f;
        game.gui.settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public override void UpdateState(GameStateMachine game)
    {
        if (game.sceneBehaviour.GetCurrentScene() != 0)
        {
            if (Input.GetButtonDown("Pause"))
            {
                game.SetState(game.playState);
            }
        }
    }
}
