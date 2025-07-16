using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
  
    public void Move(float xInput)
    {
        Debug.Log("Input : " + xInput);
        rb.velocity = new Vector2 (xInput * playerData.moveSpeed, rb.velocity.y);

        if (xInput != 0) sr.flipX = xInput < 0;  

        animator?.SetFloat("speed", Mathf.Abs(xInput));

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
