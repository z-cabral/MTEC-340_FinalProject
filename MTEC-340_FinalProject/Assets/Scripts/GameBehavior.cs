using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public GameObject Player;
    public Transform PlayerPos;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(Instance);

    }

    void Start()
    {
        if (Player != null)
        {
            PlayerPos = Player.transform;
        }
    }

    void Update()
    {
        if (Player != null)
        {
            PlayerPos = Player.transform;
        }
    }

    public void SetupPlayer()
    {
        Player = PlayerStateMachine.Instance.gameObject;
    }

    public void SetupPlayer(Vector3 position)
    {
        //Player = PlayerStateMachine.Instance.gameObject;
        Player.transform.position = position;
    }

    public void SavePlayer()
    {
        Debug.Log("I'm Saving...");
        SaveSystem.SavePlayer(Player);
    }

    public void LoadPlayer()
    {
        Debug.Log("I'm Loading...");
        PlayerData data = SaveSystem.LoadPlayer();

        SceneBehaviour.Instance.ChangeToScene(data.scene + 1);

        GuiBehaviour.Instance.Pause();

        Vector3 position;
        
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log("Loading Player at " + position + "...");

        SetupPlayer(position);
    }
}
