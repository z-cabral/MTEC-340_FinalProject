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

        Player = PlayerStateMachine.Instance.gameObject;

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

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(Player.GetComponent<PlayerStateMachine>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneBehaviour.Instance.ChangeToScene(data.scene);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        Player.transform.position = position;
    }
}
