using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Slider slider;
    public void DoSomething()
    {
        Debug.Log(slider.value.ToString());
    }
}
