using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameBaseState
{
    public override void EnterState(GameStateMachine game)
    {
        //game.sceneBehaviour.LoadScene(0);
        Time.timeScale = 1f;
        game.gui.settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        game.gui.ResetGameOverScreen();
        game.gui.GameOverScreen.SetActive(false);
        Time.timeScale = 0f;

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
