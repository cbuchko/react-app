using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeMonitor : MonoBehaviour
{
    public int startingHype = 0;
    public int maxHype = 4;
    public int currentHype;

    private int hypeCount;

    public bool isTimerRunning;
    private float baseTime = 30;
    public float timeRemaining = 30;

    public hypeBlink hypeBlink;
    

    public HypeBar hypeBar;
    // Start is called before the first frame update
    void Start()
    {
        isTimerRunning = false;
        currentHype = startingHype;
        hypeBar.SetHype(startingHype);
        hypeBar.SetMaxHype(maxHype);
    }
    // Update is called once per frame
    void Update()
    {     
        if(currentHype > 0){
            isTimerRunning = true;
        }

        hypeBar.SetHype(currentHype);
        hypeTimer();

        if(timeRemaining <= baseTime/3)
        {
            hypeBlink.blinkBar();
        } else {
            hypeBlink.stopBlinking();
        }
    }

    public void incrementHype()
    {
        timeRemaining = baseTime;
        if(currentHype < maxHype)
        {
            currentHype += 1;
        }
    }

    public void resetHype()
    {
        currentHype = 0;
        //Debug.Log("Current Hype: " + currentHype);
    }

    private void drainHype()
    {
        currentHype -= 1;
    }

    private void hypeTimer()
    {
        if(isTimerRunning)
        {
            if(timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;

            } else {

                drainHype();
                                
                if(currentHype > 0){
                    timeRemaining = 10;
                    isTimerRunning = true;
                } else {
                    timeRemaining = baseTime;
                    isTimerRunning = false;
                }
                
            }
        }

    }
}
