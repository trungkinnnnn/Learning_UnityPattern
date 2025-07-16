using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private float currentVelocityX = 0f;

    // Data
    [SerializeField] PlayerData playerData;

    // Component
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
        var targetVelocityX = xInput * playerData.moveSpeed;

        currentVelocityX = Mathf.Lerp(currentVelocityX, targetVelocityX, Time.deltaTime * playerData.acceleration);

        rb.velocity = new Vector2 (currentVelocityX, rb.velocity.y);

        if (xInput != 0) sr.flipX = xInput < 0;  

        animator?.SetFloat("speed", Mathf.Abs(currentVelocityX));

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
