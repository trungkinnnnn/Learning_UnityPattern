
public class PlayerRunState : IPlayerState
{
    private PlayerController Controller;

    public void Enter(PlayerController controller)
    {
        this.Controller = controller;
        controller.Animator.SetBool("isRunning", true); 
    }
    public void Update() 
    {
        float x = Controller.PlayerInput.MoveInput.x;

        Controller.PlayerMovement.Move(x);   

        if (x == 0)
        {
            Controller.ChangeState(new PlayerIdleState());
            return;
        }   
        
        if (Controller.PlayerInput.JumpPressed)
        {
            Controller.ChangeState(new PlayerJumState());
            return;
        }

        if (Controller.PlayerInput.AttactPressed)
        {
            Controller.ChangeState(new PlayerAttackState());
            return;
        }    

    }
    public void Exit() 
    {
        Controller.Animator.SetBool("isRunning", false);
    }
}
