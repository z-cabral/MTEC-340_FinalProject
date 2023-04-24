using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int scene;
    public float[] position;
    public float[] rotation;

    public PlayerData (GameObject player)
    {
        //scene = SceneBehaviour.Instance.GetCurrentScene();
        scene = SceneManager.GetActiveScene().buildIndex;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        rotation = new float[4];
        rotation[0] = player.transform.rotation.w;
        rotation[1] = player.transform.rotation.x;
        rotation[2] = player.transform.rotation.y;
        rotation[3] = player.transform.rotation.z;

    }
}
