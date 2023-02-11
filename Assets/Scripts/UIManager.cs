using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider speedSliderBall;
    public Dropdown colorDropdown;
    public Text speedText;

    public static float speed = 400f;
    public static int color = 0;

    void Start(){
		  speedSliderBall.value = speed;
    }

    public void changeSliderVal(){
		  speed = speedSliderBall.value;
		  speedText.text = speed.ToString();
	  }

    public void selectColor(){
      color = colorDropdown.value;
    }
}
