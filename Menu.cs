using CI.QuickSave;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CI.QuickSave;
using System;
using TMPro;

public class Menu : MonoBehaviour
{
    Animatron4_move animatron4_Move;
   // [SerializeField] GameObject animatron4;
    public Text night;
    public Text animatron1_AI_text;
    public Text animatron2_AI_text;
    public Text animatron3_AI_text;
    public Text animatron4_AI_text;
    public static int Night = 1;
    public static int animatron1_AI = 0;
    public static int animatron2_AI = 0;
    public static int animatron3_AI = 0;
    public static int animatron4_AI = 0;
    public GameObject warning_screen;
    public GameObject Menu_Game_transition;
    public GameObject foxy_plushie;
    public GameObject bonnie_plushie;
    public GameObject chica_plushie;
    public GameObject gf_plushie;
    public GameObject freddy_plushie;
    public GameObject Menu_to_custom_night_timeline;
    public GameObject Custom_night_to_menu_timeline;
    public GameObject Menu_to_Credits;
    public GameObject Custom_night_play;
    public GameObject Star_1;
    public GameObject Star_2;
    public GameObject Star_3;
    public GameObject credits;
    public GameObject Menu_fixed;
    public GameObject Lobby_terrain;
    public Button Custom_Night_button;
    public Text custom_night_text;
    public Animator anim;
    private bool json_exist = false;
    public static bool star_1 = false;
    public static bool star_2 = false;
    public static bool star_3 = false;
    public static bool custom_night = false;
    public static bool door_active = false;
    public static bool tv_active = false;
    public static bool hide_under_bed_active = false;
    public static  QuickSaveWriter writer;
    public static  QuickSaveReader reader;

    // Start is called before the first frame update

    void Start()
    {
        if (End_GF_Night.ending_credits == true)
        {
            //End_GF_Night.ending_credits != null 
            warning_screen.SetActive(false);
            credits.SetActive(true);
        }
         Debug.Log(Application.persistentDataPath);
        // QuickSaveWriter.DeleteRoot("RootName");
        //reader = QuickSaveReader.Create("Save_file");
        writer = QuickSaveWriter.Create("Save_file");
        writer.Write("void", 1).Commit();
        reader = QuickSaveReader.Create("Save_file");
        if (reader.TryRead("Night", out Night) == false)
        {
            Debug.Log("T");
            writer.Write("Night", 1).Commit();
            writer.Write("Star_1", false).Commit();
            writer.Write("Star_2", false).Commit();
            writer.Write("Star_3", false).Commit();
        }
        //dev------------------------------------------
        /*
        writer.Write("Night", 5).Commit();
        writer.Write("Star_1", true).Commit();
        writer.Write("Star_2", true).Commit();
        writer.Write("Star_3", true).Commit();*/
        //------------------------------------------

        reader.Reload();
        Night = reader.Read<int>("Night");
        star_1 = reader.Read<bool>("Star_1");
        star_2 = reader.Read<bool>("Star_2");
        star_3 = reader.Read<bool>("Star_3");

        if (star_2)
        {
            Custom_Night_button.interactable = true;
            custom_night_text.color = new Color32(56, 56, 56, 255);
        }
        else
        {
            Custom_Night_button.interactable = false;
            custom_night_text.color = new Color32(40, 40, 40, 255);
        }
        switch (Night)
        {
            case 1:
                night.text = "";
                chica_plushie.SetActive(true);
                break;
            case 2:
                
                night.text = "Night 2";
                foxy_plushie.SetActive(true);
                break;
            case 3:
               
                night.text = "Night 3";
                bonnie_plushie.SetActive(true);
                break;
            case 4:
               
                night.text = "Night 4";
                freddy_plushie.SetActive(true);
                break;
            case 5:
               
                night.text = "Night 5";
                gf_plushie.SetActive(true);
                break;
            case 6:
                night.text = "Night 5";
                break;

        }
        Set_Stars();
        //anim.SetBool("Transition", true);
    }
    private void Update()
    {
        //dev---------------------------------------------
        /*
        if (Input.GetKey(KeyCode.Alpha2))
        {
            writer.Write("Night", 2).Commit();
            Night = 2;
            Continue_Game();
        }else if (Input.GetKey(KeyCode.Alpha3))
        {
            writer.Write("Night", 3).Commit();
            Night = 3;
            Continue_Game();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            writer.Write("Night", 4).Commit();
            Night = 4;
            Continue_Game();
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            writer.Write("Night", 5).Commit();
            Night = 5;
            Continue_Game();
        }*/
        //---------------------------------------------
    }

    public void New_Game()
    {
        Debug.Log("Przed zapisem: Night = " + Night);
        Night = 1;
        writer.Write("Night", Night).Commit();
        Menu_Game_transition.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("lobby_music");
        Time.timeScale = 1;
        SetAI();
        StartCoroutine(Transition.LoadLevel());
    }
    public void Continue_Game()
    {
        Menu_Game_transition.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("lobby_music");
        Time.timeScale = 1;
        SetAI();
        StartCoroutine(Transition.LoadLevel());
    }
    public void Menu_to_Custom_Night()
    {
        Custom_night_to_menu_timeline.SetActive(false);
        Menu_to_custom_night_timeline.SetActive(true);
    }
    public void Custom_Night_to_Menu()
    {   
            custom_night = true;
            Menu_to_custom_night_timeline.SetActive(false);
            Custom_night_to_menu_timeline.SetActive(true);
    }
    public void Custom_Night_play()
    {
        FindObjectOfType<AudioManager>().Stop("lobby_music");
        Night = 6;
        writer.Write("Night", Night).Commit();
        Debug.Log(animatron1_AI);
        Debug.Log(animatron2_AI);
        Debug.Log(animatron3_AI);
        Debug.Log(animatron4_AI);
        door_active = true;
        tv_active = true;
        hide_under_bed_active = true;
        Custom_night_play.SetActive(true);
        StartCoroutine(Transition.LoadLevel());
    }
    public void Credits()
    {
        FindObjectOfType<AudioManager>().Stop("lobby_music");
        Menu_to_Credits.SetActive(true);
        Invoke(nameof(Credits_2),0.5f);
    }
    public void Credits_2()
    {
        Menu_fixed.SetActive(false);
        Lobby_terrain.SetActive(false);
    }
    public void Quit_Game()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    private void SetAI()
    {
        reader.Reload();
        Night = reader.Read<int>("Night");
        switch (Night)
        {     
            case 0:
                //def night
                animatron1_AI = 0;
                animatron2_AI = 0;
                animatron3_AI = 20;
                animatron4_AI = 0;
                break;
            case 1:
                animatron1_AI = 0;
                animatron2_AI = 5;
                animatron3_AI = 0;
                animatron4_AI = 0;
                break;
            case 2:
                animatron1_AI = 5;
                animatron2_AI = 10;
                animatron3_AI = 0;
                animatron4_AI = 0;
                break;
            case 3:
                animatron1_AI = 10;
                animatron2_AI = 15;
                animatron3_AI = 0;
                animatron4_AI = 0;
                break;
            case 4:
                animatron1_AI = 15;
                animatron2_AI = 20;
                animatron3_AI = 10;
                animatron4_AI = 5;
                door_active = true;
                break;
            case 5:
                animatron1_AI = 0;
                animatron2_AI = 0;
                animatron3_AI = 0;
                animatron4_AI = 0;
                door_active = true;
                tv_active = true;
                hide_under_bed_active = true;
                break;
        }
    }
    private void Set_Stars()
    {
       if(star_1)
        {
            Star_1.SetActive(true);
        }
        if (star_2)
        {
            Star_2.SetActive(true);
        }
        if (star_3)
        {
            Star_3.SetActive(true);
        }
    }
    public void Button_click()
    {
        FindObjectOfType<AudioManager>().Play("button_click_sound");
    }
}
