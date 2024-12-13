//Matthew Gocool  12/05/24
public abstract class BaseState
{
    public StateMachine stateMachine;


    public Enemy enemy;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();


}