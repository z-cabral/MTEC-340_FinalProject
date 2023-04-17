public abstract class GuardBaseState
{
    public abstract void EnterState(GuardStateMachine guard);

    public abstract void UpdateState(GuardStateMachine guard);
}
