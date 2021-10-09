using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 player_position;

    // Update is called once per frame
    void Update()
    {
        player_position = GetComponent<Transform>().position;
        if(player_position.y < -6){
            // GetComponent<Transform>().position = new Vector3(-8, 0, 0);
            // GetComponent<PlayerMovement>().jumpCount = 0;
            // GetComponent<PlayerMovement>().count = 0;
            // //GetComponent<PlayerMovement>().isGrounded = true;
            // GetComponent<PlayerMovement>().isJumping = false;
            Application.LoadLevel(Application.loadedLevel);
        }
        
    }
}
