using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; }
    public bool JumpPressed {  get; private set; }
    public bool AttactPressed { get; private set; } 

    public void SetMoveInput(Vector2 input) => MoveInput = input;

    public void OnJumpButtonDown() => JumpPressed = true;
    public void OnAttackButtonDown() => AttactPressed = true;
    
    public void LateUpdate()
    {
        JumpPressed = false;
        AttactPressed = false;
    }

}
