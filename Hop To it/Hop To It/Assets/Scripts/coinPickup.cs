using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinPickup : MonoBehaviour
{

    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        int startCount = 0;
        coinText.text = startCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        other.GetComponent<PlayerResources>().incrementCoinCount();
        coinText.text = other.GetComponent<PlayerResources>().coinCount.ToString();
        Destroy(gameObject);
    }
}
