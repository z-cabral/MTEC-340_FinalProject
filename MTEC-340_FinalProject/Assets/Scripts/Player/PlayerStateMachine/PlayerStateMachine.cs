using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStateMachine Instance;

    PlayerBaseState _currentState;
    public PlayerBaseState CurrentState { get => _currentState; }

    public PlayerGameplayState GameplayState = new();
    public PlayerInvisibleState InvisibleState = new ();

    bool _isInvisible;
    public bool isInvisible { get => _isInvisible; set { _isInvisible = value; } }

    public FPSInput fpsInput;
    public LaserBehaviour laser;
    public MouseLook mouseHead, mouseBody;
    public PlayerUtilities utils;

    private void OnLevelWasLoaded(int scene)
    {
        //GameBehavior.Instance.SetupPlayer();
        if(GameStateMachine.Instance.IsLoadingSaveData == true)
        {
            if (scene > 1)
            {
                this.transform.SetLocalPositionAndRotation(GameStateMachine.Instance.utils.position, GameStateMachine.Instance.utils.rotation);
            }
        }
        if (scene > 0)
        {
            GameStateMachine.Instance.SetState(GameStateMachine.Instance.playState);
        }

    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        fpsInput = GetComponent<FPSInput>();
        laser = GetComponentInChildren<LaserBehaviour>();
        mouseHead = GetComponentInChildren<MouseLook>();
        mouseBody = GetComponent<MouseLook>();
    }
    private void Start()
    {
        SetState(GameplayState);
    }
    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SetState(PlayerBaseState newState)
    {
        _currentState = newState;
        _currentState.EnterState(this);
    }
}

