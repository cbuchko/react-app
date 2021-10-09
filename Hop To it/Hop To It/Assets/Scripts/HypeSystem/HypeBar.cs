using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HypeBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHype(int hype)
    {
        slider.maxValue = hype;
    }

    public void SetHype(int hype)
    {
        slider.value = hype;

    }
}
