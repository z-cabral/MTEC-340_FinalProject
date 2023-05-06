using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStateMachine : MonoBehaviour
{
    GuardBaseState _currentState;

    public GuardUnalertState UnalertState = new();
    public GuardSuspiciousState SuspiciousState = new();
    public GuardAlertState AlertState = new();
    public GuardDeactivatedState DeactivatedState = new();

    bool _isPowered;
    public bool IsPowered{get => _isPowered; set { _isPowered = value; }}

    bool _deactivateable;
    public bool Deactivateable { get => _deactivateable; set { _deactivateable = value;  } }

    public ReactiveTarget ReactiveTarget;
    public EnemyMovement EnemyMovement;
    public EnemySight HeadSight;
    public EnemySight BodySight;
    public EnemyUtilities Utilities;
    public GuardAudio Audio;

    public Vector3 playerLast;

    void Awake()
    {
        EnemyMovement = GetComponent<EnemyMovement>();
        ReactiveTarget = GetComponent<ReactiveTarget>();
        HeadSight = GetComponentInChildren<EnemySight>();
        BodySight = GetComponent<EnemySight>();
        Utilities = GetComponent<EnemyUtilities>();
        Audio = GetComponent<GuardAudio>();
    }

    private void Start()
    {
        //PlayerPos = GameBehavior.Instance.Player.transform;

        SetState(UnalertState);
    }

    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SetState(GuardBaseState newState)
    {
        _currentState = newState;
        _currentState.EnterState(this);
    }
}
