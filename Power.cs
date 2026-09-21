using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    //public GameObject power_text;
    public Text power_text;
    public Light flashlight1;
    public Light flashlight2;
    public Light flashlight3;
    public Light flashlight4;
    private double power = 100f;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flashlight1.tag=="flashlight_active" || flashlight2.tag == "flashlight_active" || flashlight3.tag == "flashlight_active" || flashlight4.tag == "flashlight_active")
        {
            power -= Time.deltaTime/3;
        }
        power -= Time.deltaTime / 8;
        power_text.text = "Power: \n" + Math.Ceiling(power).ToString() + "%";
        if(power <= 0)
        {
            GameOver.SetActive(true);
        }
    }
}
