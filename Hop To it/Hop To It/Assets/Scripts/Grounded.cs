using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    public bool newJumpLocation;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
        newJumpLocation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.collider.tag == "Ground"){

            Player.GetComponent<PlayerMovement>().isGrounded = true;
            Player.GetComponent<PlayerMovement>().anim.SetBool("onGround", true);

            
            if(collision.collider.GetComponent<GroundCheck>().visited == 0){
                // /Debug.Log("Collision Check!" + collision.collider.GetComponent<GroundCheck>().visited);

                //Remember to fix race condition with this at some point
                Player.GetComponent<PlayerMovement>().newJumpLocation = true;
            } else if(collision.collider.GetComponent<GroundCheck>().runway){

                Player.GetComponent<PlayerMovement>().onRunway = true;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            //Player.GetComponent<PlayerMovement>().isGrounded = false;
            Player.GetComponent<PlayerMovement>().newJumpLocation = false;

        }

    }
}

