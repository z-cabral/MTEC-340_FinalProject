using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameBaseState
{
    public override void EnterState(GameStateMachine game)
    {
        Time.timeScale = 1f;
        game.gui.settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void UpdateState(GameStateMachine game)
    {
        if (Input.GetButtonDown("Pause"))
        {
            game.SetState(game.menuState);
        }
    }
}
