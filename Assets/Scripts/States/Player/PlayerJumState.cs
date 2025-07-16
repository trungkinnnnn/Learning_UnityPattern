
public class PlayerJumState : IState<PlayerController>
{
    public void Enter(PlayerController controller) 
    {
        controller.PlayerMovement.Jump();
    }
    public void Update(PlayerController controller) 
    {
      
    }
    public void Exit(PlayerController controller) { }
}
