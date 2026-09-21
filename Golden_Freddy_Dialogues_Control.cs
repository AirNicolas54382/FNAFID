using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Video;

public class Golden_Freddy_Dialogues_Control : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject GF_Plushie_dummy;
    public GameObject GF_apperance_timeline; 
    public GameObject GF_disappearing_timeline;
    public GameObject Lightrise;
    public GameObject GF_Dialogue_apperance2;
    //public GameObject Phone_throw;
    public GameObject documents_show;
    public GameObject document_render;
    public GameObject document_on_fire_render;
    public GameObject video_player;
    public GameObject ui_for_video;
    public GameObject GF_last_words_timeline;
    public GameObject Magic_trick;

    //public GameObject GF_apperance_6AM_timeline;
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }
    public void Glitch_sound()
    {
        FindObjectOfType<AudioManager>().Play("gf_glitch_sound");
    }
    public void Glitch_sound_stop_Ambient1_start()
    {
        FindObjectOfType<AudioManager>().Stop("gf_glitch_sound");
        FindObjectOfType<AudioManager>().Stop("ambient");
        FindObjectOfType<AudioManager>().Play("GF_dialogue_ambient1");
    }
  /*  public void GF_apperance1()
    {
        director.Play();
        GF_Plushie_dummy.SetActive(true);
    }*/
    public void Ambient2_start_GF_apperance1()
    {
        GF_apperance_timeline.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("GF_dialogue_ambient1");
        FindObjectOfType<AudioManager>().Play("GF_dialogue_ambient2");
    }
    public void Ambient2_Stop_GF_disappearing()
    {
        GF_disappearing_timeline.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("GF_dialogue_ambient2");
    }
    public void Lightrise_()
    {
        Lightrise.SetActive(true);
    }
    public void GF_apperance2()
    {
        GF_Dialogue_apperance2.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("GF_dialogue_ambient1");
        FindObjectOfType<AudioManager>().Play("GF_dialogue_ambient2");
        FindObjectOfType<AudioManager>().Stop("win_ringstone");
    }
    public void GF_magic_Trick()
    {
        Magic_trick.SetActive(true);
    }
    public void Stop_Ambient2()
    {
        FindObjectOfType<AudioManager>().Stop("GF_dialogue_ambient2");
    }
    public void Phone_throw_function2()
    {
       // Phone_throw.SetActive(true);
    }
    public void Darell_ending_dialog_ambient()
    {
        FindObjectOfType<AudioManager>().Play("Darell_ending_dialog_ambient");
    }
    public void Documents_show()
    {
        documents_show.SetActive(true);
        // documents.SetActive(true);
    }
    public void Documents_fire()
    {
        video_player.SetActive(true);
        document_render.SetActive(false);
        document_on_fire_render.SetActive(true);
        //  ui_for_video.SetActive(true);
        Invoke(nameof(GF_last_words), 5f);
        FindObjectOfType<AudioManager>().Stop("Darell_ending_dialog_ambient");
        FindObjectOfType<AudioManager>().Play("fire");
    }
    public void GF_last_words()
    {
        documents_show.SetActive(false);
        document_on_fire_render.SetActive(false);
        video_player.SetActive(false);
        GF_last_words_timeline.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("fire");
    }

}
