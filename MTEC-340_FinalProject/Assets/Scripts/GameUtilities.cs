using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtilities : MonoBehaviour
{
    Transform PlayerTransform;

    public Vector3 position;
    public Quaternion rotation;
    public void SaveGame()
    {
        //GameObject Player = FindPlayer();
        GameObject Player = PlayerStateMachine.Instance.gameObject;

        if(Player != null)
        {
            SaveSystem.SavePlayer(Player);
        }
        else
        {
            Debug.Log("No Player Found...");
        }
    }

    public void LoadGame()
    {
        //GameStateMachine.Instance.SetState(GameStateMachine.Instance.loadingState);
        LoadPlayer();


        //PlayerStateMachine.Instance.transform.SetPositionAndRotation(transform.position, transform.rotation);

        //Debug.Log("No Save Data Found...");
    }


    public void SavePlayer(GameObject Player)
    {
        Debug.Log("I'm Saving...");
        SaveSystem.SavePlayer(Player);
    }

    public void LoadPlayer()
    {
        Debug.Log("I'm Loading...");
        PlayerData data = SaveSystem.LoadPlayer();

        GameStateMachine.Instance.sceneBehaviour.LoadScene(data.scene);

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        rotation.w = data.rotation[0];
        rotation.x = data.rotation[1];
        rotation.y = data.rotation[2];
        rotation.z = data.rotation[3];
        Debug.Log("Loading Player at " + position + rotation + "...");


        //OnLevelWasLoaded(data.scene);
        //return PlayerTransform;

        //SetupPlayer(position);
    }

    private void OnLevelWasLoaded(int level)
    {
       // PlayerTransform = FindPlayer().transform;

       // PlayerTransform.SetPositionAndRotation(position, rotation);
    }

    public GameObject FindPlayer()
    {
        GameObject Player = GameObject.Find("Player");

        //GameObject Player = FindObjectOfType(typeof(PlayerStateMachine)) as GameObject;

        Debug.Log(Player.name);
        if (Player != null)
        {
            return Player;
        }
        else
        {
            return null;
        }       
    }
}
