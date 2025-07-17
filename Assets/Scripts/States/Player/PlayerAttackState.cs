
using UnityEngine;

public class PlayerAttackState : IState<PlayerController>
{
    private float timer = 0.5f;
    public int Priority => 2;

    public void Enter(PlayerController controller) 
    {
        controller.Animator.SetTrigger("Attack");
    }
    public void Update(PlayerController controller) 
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            controller.stackStateMachine.PopState();
        }
    }
    public void Exit(PlayerController controller) { }
}
