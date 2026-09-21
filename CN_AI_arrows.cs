using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CN_AI_arrows : MonoBehaviour
{
    public Text animatron1_AI_text;
    public Text animatron2_AI_text;
    public Text animatron3_AI_text;
    public Text animatron4_AI_text;
    public static int ai1;
    public static int ai2;
    public static int ai3;
    public static int ai4;
    Color color;
    private void Start()
    {
        animatron1_AI_text.text = "00";
        animatron2_AI_text.text = "00";
        animatron3_AI_text.text = "00";
        animatron4_AI_text.text = "00";
        Menu.animatron1_AI = 0;
        Menu.animatron2_AI = 0;
        Menu.animatron3_AI = 0;
        Menu.animatron4_AI = 0;
        color = new Color(50f / 255f, 50f / 255f, 50f / 255f); 
    }
    public void CN_AI_Left_Arrow(int i)
    {       
            switch (i)
            {
                case 1:
                if (Menu.animatron1_AI > 0)
                {
                    Menu.animatron1_AI = Menu.animatron1_AI-1;
                  //  Debug.Log(Menu.animatron1_AI);
                    animatron1_AI_text.text = Menu.animatron1_AI.ToString();
                    if (Menu.animatron1_AI <= 9)
                    {
                        animatron1_AI_text.text = "0" + animatron1_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
                
                case 2:
                if (Menu.animatron2_AI > 0)
                {
                    Menu.animatron2_AI--;
                    animatron2_AI_text.text = Menu.animatron2_AI.ToString();
                    if (Menu.animatron2_AI <= 9)
                    {
                        animatron2_AI_text.text = "0" + animatron2_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
                case 3:
                if (Menu.animatron3_AI > 0)
                {
                    Menu.animatron3_AI--;
                    animatron3_AI_text.text = Menu.animatron3_AI.ToString();
                    if (Menu.animatron3_AI <= 9)
                    {
                        animatron3_AI_text.text = "0" + animatron3_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
                case 4:
                if (Menu.animatron4_AI > 0)
                {
                    Menu.animatron4_AI--;
                    animatron4_AI_text.text = Menu.animatron4_AI.ToString();
                    if (Menu.animatron4_AI <= 9)
                    {
                        animatron4_AI_text.text = "0" + animatron4_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
            }
   
        max_mode_text_color();
    }
    public void CN_AI_Right_Arrow(int i)
    {        
            switch (i)
            {
                case 1:
                if (Menu.animatron1_AI < 20)
                {
                    Menu.animatron1_AI++;
                    animatron1_AI_text.text = Menu.animatron1_AI.ToString();
                    if (Menu.animatron1_AI <= 9)
                    {
                        animatron1_AI_text.text = "0" + animatron1_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");               
                }
                    break;
                case 2:
                if (Menu.animatron2_AI < 20)
                {
                    Menu.animatron2_AI++;
                    animatron2_AI_text.text = Menu.animatron2_AI.ToString();
                    if (Menu.animatron2_AI <= 9)
                    {
                        animatron2_AI_text.text = "0" + animatron2_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
                case 3:
                if (Menu.animatron3_AI < 20)
                {
                    Menu.animatron3_AI++;
                    animatron3_AI_text.text = Menu.animatron3_AI.ToString();
                    if (Menu.animatron3_AI <= 9)
                    {
                        animatron3_AI_text.text = "0" + animatron3_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
                case 4:
                if (Menu.animatron4_AI < 20)
                {
                    Menu.animatron4_AI++;
                    animatron4_AI_text.text = Menu.animatron4_AI.ToString();
                    if (Menu.animatron4_AI <= 9)
                    {
                        animatron4_AI_text.text = "0" + animatron4_AI_text.text;
                    }
                    FindObjectOfType<AudioManager>().Play("arrows_sound");
                }
                    break;
            }
       
        max_mode_text_color();
    }
    public void Max_mode()
    {
        Menu.animatron1_AI = 20;
        Menu.animatron2_AI = 20;
        Menu.animatron3_AI = 20;
        Menu.animatron4_AI = 20;  
        animatron1_AI_text.text = Menu.animatron4_AI.ToString();
        animatron2_AI_text.text = Menu.animatron4_AI.ToString();
        animatron3_AI_text.text = Menu.animatron4_AI.ToString();
        animatron4_AI_text.text = Menu.animatron4_AI.ToString();
        max_mode_text_color();
    }
    public void max_mode_text_color()
    {
        if(Menu.animatron1_AI == 20 && Menu.animatron2_AI == 20 && Menu.animatron3_AI == 20 && Menu.animatron4_AI == 20)
        {
            animatron1_AI_text.color = Color.red;
            animatron2_AI_text.color = Color.red;
            animatron3_AI_text.color = Color.red;
            animatron4_AI_text.color = Color.red;
        }
        else
        {
            animatron1_AI_text.color = color;
            animatron2_AI_text.color = color;
            animatron3_AI_text.color = color;
            animatron4_AI_text.color = color;
        }
    }


}
