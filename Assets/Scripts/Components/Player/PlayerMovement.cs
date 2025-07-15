using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();
  
    public void Move(float xInput)
    {
        rb.velocity = new Vector2 (xInput * playerData.moveSpeed, rb.velocity.y);
    }    

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, playerData.jumpForce);
    }    

    public void Dash()
    {
        rb.velocity = new Vector2 (transform.localScale.x * playerData.dashForce, rb.velocity.y);
    }    

    public bool IsGround()
    {
        return Mathf.Abs(rb.velocity.y) < 0.1f;
    }    


}
