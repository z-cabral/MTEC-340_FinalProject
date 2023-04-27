using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //GameStateMachine.Instance.SetState(GameStateMachine.Instance.gameOver);
        GameStateMachine.Instance.sceneBehaviour.NextScene();
    }
}
