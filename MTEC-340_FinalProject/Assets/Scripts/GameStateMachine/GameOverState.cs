using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{
    public override void EnterState(GameStateMachine game)
    {
        Debug.Log("Entering GAME OVER...");
        Time.timeScale = 1f;
        game.gui.settingsMenu.SetActive(false);
        game.gui.GameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void UpdateState(GameStateMachine game)
    {
        bool finished = game.gui.FadeOut();

        if (finished)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0f;

            //Open Gui to Start Over
        }
    }
}
