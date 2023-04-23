using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int scene;
    public float[] position;

    public PlayerData (PlayerStateMachine player)
    {
        scene = SceneBehaviour.Instance.currentScene;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
