
using UnityEngine;

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


        if(Mathf.Abs(input.MoveInput.x) > 0.1f)
        {
            controller.PlayerMovement.Move(input.MoveInput.x);
        }
        else
        {
            controller.PlayerMovement.Move(0);
        }



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
