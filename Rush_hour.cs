using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Rush_hour : MonoBehaviour
{

     public static GameObject Normal_post_processing;
     public static GameObject Rush_hour_post_processing;
     private static PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        Normal_post_processing = GameObject.Find("Post_Process");
        Rush_hour_post_processing = GameObject.Find("Rush_hour");
        Rush_hour_post_processing.SetActive(false);
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Rush_hour_function()
    {
        director.Play();
        Normal_post_processing.SetActive(false);
        Rush_hour_post_processing.SetActive(true);
        //  FindObjectOfType<AudioManager>().Play("heart_beat");
        FindObjectOfType<AudioManager>().Stop("clock");
        FindObjectOfType<AudioManager>().Stop("GF_Stage_I_ambient");
        FindObjectOfType<AudioManager>().Play("rush_hour_ambient");
        FindObjectOfType<AudioManager>().Play("intense_clock_ticking");
        
       if(Menu.animatron1_AI != 0)
        {
            Menu.animatron1_AI += 3;
            if(Menu.animatron1_AI > 20)
            {
                Menu.animatron1_AI = 20;
            }       
        }
       if(Menu.animatron2_AI != 0)
        {
            Menu.animatron2_AI += 3;
            if (Menu.animatron2_AI > 20)
            {
                Menu.animatron2_AI = 20;
            }

        }
        if (Menu.animatron3_AI != 0)
        {
            Menu.animatron3_AI += 3;
            if (Menu.animatron3_AI > 20)
            {
                Menu.animatron3_AI = 20;
            }

        }
        if (Menu.animatron4_AI != 0)
        {
            Menu.animatron4_AI += 3;
            if (Menu.animatron4_AI > 20)
            {
                Menu.animatron4_AI = 20;
            }

        }
    }
    public static void Post_Processing_function()
    {
        director.Play();
        Normal_post_processing.SetActive(true);
        Rush_hour_post_processing.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("intense_clock_ticking");
        FindObjectOfType<AudioManager>().Stop("rush_hour_ambient");
    }
}
