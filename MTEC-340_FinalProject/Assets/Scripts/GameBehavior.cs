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

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void Start()
    {
        PlayerPos = Player.transform;
    }

    void Update()
    {
        PlayerPos = Player.transform;
    }
}
