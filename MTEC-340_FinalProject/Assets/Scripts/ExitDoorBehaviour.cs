using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //GameStateMachine.Instance.SetState(GameStateMachine.Instance.gameOver);
        //if(other = PlayerStateMachine.Instance.GetComponent<CharacterController>())
        //{
        Object.Destroy(PlayerStateMachine.Instance.gameObject);
        GameStateMachine.Instance.sceneBehaviour.NextScene();
        //Transform playerSpawnpoint = Object.
        //Object.Instantiate("Player", playerSpawnPoint)

        //}
    }
}
