using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public Animator animator;
    public Rigidbody2D rb;
    private bool isJumping;
    private bool isGrounded;
    private Vector3 velocity = Vector3.zero;
    public SpriteRenderer spriteRenderer;

    void Update(){
        if(Input.GetButtonDown("Jump") && isGrounded == true){
            isJumping = true;
        }
        flipPlayer(rb.velocity.x);
        float characterVolicity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVolicity);
    }

    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,collisionLayers);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movePlayer(horizontalMovement);
        
    }
    
    void movePlayer(float _horizontalMovement){
        Vector3 targetVelocity = new Vector2(_horizontalMovement,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity,.05f);

        if(isJumping == true){
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }

    void flipPlayer(float _velocity){
        if(_velocity > 0.1f){
            spriteRenderer.flipX = false; 
        }else if (_velocity<-0.1f){
            spriteRenderer.flipX = true; 
        }
    }

    private void onDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
    }
}
