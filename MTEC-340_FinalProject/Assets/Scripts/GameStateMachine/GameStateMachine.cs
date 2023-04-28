using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance;

    GameBaseState _currentState;
    public GameBaseState CurrentState { get => _currentState; set { _currentState = value; } }

    public GameMenuState menuState = new ();
    public GamePlayState playState = new ();
    public GameLoadingState loadingState = new ();
    public GameOverState gameOver = new ();

    bool _gameOver;
    public bool GameOver { get => _gameOver; set { _gameOver = value; } }

    bool _isLoadingSaveData;
    public bool IsLoadingSaveData { get => _isLoadingSaveData; set { _isLoadingSaveData = value; } }

    public SceneBehaviour sceneBehaviour;
    public GuiBehaviour gui;
    public GameUtilities utils;
    public PostProcessingControl ppc;


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

        sceneBehaviour = GetComponent<SceneBehaviour>();
        gui = GetComponentInChildren<GuiBehaviour>();
        utils = GetComponent<GameUtilities>();
        ppc = GetComponentInChildren<PostProcessingControl>();

    }



    void Start()
    {
        SetState(menuState);
        //sceneBehaviour.LoadScene(0);
    }

    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SetState(GameBaseState newState)
    {
        _currentState = newState;
        _currentState.EnterState(this);
    }
}
