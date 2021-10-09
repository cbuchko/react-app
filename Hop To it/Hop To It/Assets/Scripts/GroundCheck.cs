using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int visited;
    public bool runway;
    // Start is called before the first frame update
    void Start()
    {
        visited = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Player"){
            visited++;
        }

    }
}
