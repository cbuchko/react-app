using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hypeBlink : MonoBehaviour
{
    Image image;
    Image baseImage;
    bool CR_running;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        baseImage = GetComponent<Image>();

    }

    public void blinkBar()
    {
        if(!CR_running){
            StopCoroutine("Blink");
            StartCoroutine("Blink");
        }
    }

    IEnumerator Blink()
    {
        CR_running = true;
        image.color = new Color(255, 0, 187, 1);
        yield return new WaitForSeconds(0.5f);
        image.color = new Color(255, 255, 0, 1);
        yield return new WaitForSeconds(0.5f);
        CR_running = false;

    }

    public void stopBlinking()
    {
        StopCoroutine("Blink");
        CR_running = false;
        image.color = new Color(255, 0, 187, 1);
    }
}
