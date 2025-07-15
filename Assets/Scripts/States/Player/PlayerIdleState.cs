
public class PlayerIdleState : IPlayerState
{
    private PlayerController controller;

    public void Enter(PlayerController controller)
    {
        this.controller = controller;
        //controller.Animator.SetBool("isJumping", false);
    }

    public void Update()
    {
        var input = controller.PlayerInput; 

        if (input.JumpPressed)
        {
            controller.ChangeState(new PlayerJumState());
            return;
        }    

        if (input.AttactPressed)
        {
            controller.ChangeState(new PlayerAttackState());
            return ;
        }    

    }

    public void Exit() { }
}
