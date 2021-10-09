using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseMoveSpeed;
    public float moveSpeed;

    public int count;
    public int jumpCount;
    public int hypeCount;
    private int startBuffer;

    public bool isGrounded = false;
    public bool isJumping = false;
    private bool isCharging = false;

    public bool newJumpLocation = false;
    public bool onRunway = false;

    private float jumpPressure;
    private float minJump;
    private float baseMaxJumpPressure;
    public float maxJumpPressure;

    public Animator anim;

    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        jumpCount = 0;
        //hypeCount = 0;
        startBuffer = 3;
        jumpPressure = 0f;
        baseMoveSpeed = 5f;
        minJump = 3f;
        baseMaxJumpPressure = 8f;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log("isJumping " + isJumping);

        if(isGrounded && count > 5){
            isJumping = false;
            count = 0;
            if(newJumpLocation){
                jumpCount++;
                if(jumpCount > startBuffer){
                    GetComponent<HypeMonitor>().incrementHype();
                }
            //if the forward motion is not kept, reset the jumpCount (in the future make it decrement not reset)
            } else if (!onRunway){
                jumpCount = 0;
                Debug.Log("hello world");
                GetComponent<HypeMonitor>().resetHype();
            }

        }

        hypeCount = GetComponent<HypeMonitor>().currentHype;

        //modify player speed based on its jump count    
        if(jumpCount <= startBuffer || hypeCount == 0){
            moveSpeed = baseMoveSpeed;
            maxJumpPressure = baseMaxJumpPressure;
        } else {
            
            moveSpeed = baseMoveSpeed*(hypeCount+1)/(float)1.8;
            maxJumpPressure = baseMaxJumpPressure + hypeCount/(float)1.8;
            
        }
       
        if(isJumping){
            count++;
        }    

        Jump();

        //Only allow horizontal movement if the player is not chargin a jump and not currently mid jump.
        if(isCharging == false && isJumping == false)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }

    void Jump(){
        if(isGrounded){
            //jump is being charged
            if (Input.GetKey("w"))
            {
                isCharging = true;
                if(jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime*10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                    anim.SetBool("maxJump", true);
                }
                anim.SetFloat("jumpPressure", (jumpPressure + minJump));
            }
            else 
            {
                //jump has been released
                if(jumpPressure > 0f)
                {

                    //if jump was tapped, make it a horizontal jump
                    if(jumpPressure <= maxJumpPressure/3){
                        Debug.Log("Horizontal Jump");
                        jumpPressure = jumpPressure + (minJump + hypeCount);
                        if(hypeCount > 0){
                            rbody.velocity = new Vector2(jumpPressure, jumpPressure/2);
                        } else{
                            rbody.velocity = new Vector2(jumpPressure, jumpPressure);
                        }
                        
                        
                    } else {
                        Debug.Log("Vertical Jump");
                        jumpPressure = jumpPressure + minJump;
                        rbody.velocity = new Vector2(jumpPressure/5, jumpPressure);
                    }

                    jumpPressure = 0f;
                    isCharging = false;
                    isGrounded = false;
                    isJumping = true;
                    newJumpLocation = false;
                    onRunway = false;
                    anim.SetFloat("jumpPressure", 0f);
                    anim.SetBool("onGround", false);
                    anim.SetBool("maxJump", false);
   
                }
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision){
    //     if(collision.collider.tag == "Ground"){

            

    //     }

    // }

}
