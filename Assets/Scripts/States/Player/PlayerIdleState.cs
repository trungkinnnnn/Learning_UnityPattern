
using UnityEngine;

public class PlayerIdleState : IState<PlayerController>
{
    public void Enter(PlayerController controller)
    {
       
        //controller.Animator.SetBool("isJumping", false);
    }

    public void Update(PlayerController controller)
    {
        var input = controller.PlayerInput;
        controller.PlayerMovement.Move(input.MoveInput.x);
    }

    public void Exit(PlayerController controller) { }

    public void Resume(PlayerController controller)
    {
        controller.Animator.Play("WalkRunBlend");
    }
}
