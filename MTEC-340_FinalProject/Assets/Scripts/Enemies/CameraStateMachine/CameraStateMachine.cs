using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : MonoBehaviour
{
    CameraBaseState _currentState;

    public CameraUnalertState UnalertState = new();
    public CameraSuspiciousState SuspiciousState = new();
    public CameraAlertState AlertState = new();

    bool _isPowered;
    public bool IsPowered { get => _isPowered; set { _isPowered = value; } }

    public ReactiveTarget ReactiveTarget;
    public EnemySight HeadSight;

    void Awake()
    {
        ReactiveTarget = GetComponent<ReactiveTarget>();
        HeadSight = GetComponent<EnemySight>();

    }

    private void Start()
    {
        SetState(UnalertState);
    }

    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SetState(CameraBaseState newState)
    {
        _currentState = newState;
        _currentState.EnterState(this);
    }

}
