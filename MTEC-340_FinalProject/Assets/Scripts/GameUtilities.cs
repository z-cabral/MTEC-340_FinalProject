using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtilities : MonoBehaviour
{
    public void SaveGame()
    {
        GameObject Player = FindPlayer();


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
        Debug.Log("No Save Data Found...");
    }


    public void SavePlayer(GameObject Player)
    {
        Debug.Log("I'm Saving...");
        SaveSystem.SavePlayer(Player);
    }

    public PlayerData LoadPlayer()
    {
        Debug.Log("I'm Loading...");
        PlayerData data = SaveSystem.LoadPlayer();

        //SceneBehaviour.Instance.ChangeToScene(data.scene + 1);

        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log("Loading Player at " + position + "...");

        return data;

        //SetupPlayer(position);
    }

    public GameObject FindPlayer()
    {
        GameObject Player = FindObjectOfType(typeof(PlayerStateMachine)) as GameObject;
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
