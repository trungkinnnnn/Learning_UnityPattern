using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; }
    public bool JumpPressed {  get; private set; }
    public bool AttactPressed { get; private set; } 

    public void SetMoveLeftDown() => MoveInput = Vector2.left;
    public void SetMoveRightDown() => MoveInput = Vector2.right;    

    public void StopMove() => MoveInput = Vector2.zero;

    public void OnJumpButtonDown() => JumpPressed = true;
    public void OnAttackButtonDown() => AttactPressed = true;
    
    public void LateUpdate()
    {
        JumpPressed = false;
        AttactPressed = false;
    }

}
