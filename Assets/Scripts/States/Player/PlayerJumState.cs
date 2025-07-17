

public class PlayerJumState : IState<PlayerController>
{
    public int Priority => 1;
    public void Enter(PlayerController controller) 
    {
        controller.PlayerMovement.Jump();
    }
    public void Update(PlayerController controller) 
    {
        if(controller.PlayerMovement.IsGround())
        {
            controller.stackStateMachine.PopState();
        }
    }
    public void Exit(PlayerController controller) { }
}
