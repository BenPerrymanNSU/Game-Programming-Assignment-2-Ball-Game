/*
    UIManager.cs stores static variables with input from the color dropdown, size dropdown, speed text, and speed slider.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Slider speedSliderBall;
    public Dropdown colorDropdown;
    public Dropdown sizeDropdown;
    public Text speedText;

    public static float speed = 400f;
    public static int color = 0;
    public static int size = 0;

    // At start of scene set slider and dropdown menus to static variables
    // this is to keep change options saved
    void Start(){
        speedSliderBall.value = speed;
        colorDropdown.value = color;
        sizeDropdown.value = size;
    }

    // sets static speed to speed slider value and updates speed text to match
    public void changeSliderVal(){
        speed = speedSliderBall.value;
        speedText.text = speed.ToString();
    }

    // sets static color to the color dropdown option selected
    public void selectColor(){
        color = colorDropdown.value;
    }

    // sets static size to the size dropdown option selected
    public void selectSize(){
        size = sizeDropdown.value;
    }
}
