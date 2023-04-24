public abstract class GameBaseState
{
    public abstract void EnterState(GameStateMachine player);

    public abstract void UpdateState(GameStateMachine player);
}
