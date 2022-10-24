public class BaseState
{
    private string m_StateName;
    protected StateMachine m_stateMachine;
    public BaseState(string _name, StateMachine _stateMachine)
    {
        this.m_StateName = _name;
        this.m_stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {
        return;
    }
    public virtual void UpdateLogic()
    {
        return;
    }
    public virtual void Exit()
    {
        return;
    }
}