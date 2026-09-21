using DialogueEditor;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.Video;

public class Golden_Freddy_stage_I : MonoBehaviour
{

    public GameObject GF_Plush;
    public GameObject Hidden;
    public GameObject Show_door;
    public GameObject Show_tv;
    public GameObject Show_bed;
    public GameObject Show_bedroom_1;
    public GameObject Show_bedroom_2;
    public GameObject Show_outside_the_window_1;
    public GameObject Show_outside_the_window_2;
    public GameObject GFAO_hallway;  //GFAO - Golden Freddy as object
    public GameObject GFAO_bedroom_1;
    public GameObject GFAO_bedroom_2;
    public GameObject GFAO_bedroom_3;
    public GameObject GFAO_outside_the_window_1;
    public GameObject GFAO_tv;
    public GameObject Positions_GFAO;
    public GameObject StageII_Plushies;
    public GameObject StageII_Position1;
    public GameObject StageII_Position2;
    public GameObject StageII_Position3;
    public GameObject StageII_Position4;
    public GameObject flashlight_status;
    public GameObject door_pos_flashlight_status;
    public GameObject door_pos;
    public GameObject tv_pos;
    public GameObject bed_pos;
    public GameObject escape_render;
 //   public GameObject videoObject;
    public GameObject clock;
    public GameObject door_position;
    public GameObject tv_position;
    public GameObject hide_under_bed_position;
    public GameObject Position1;
    public GameObject Player_Camera;
    public GameObject Position2;
    public GameObject Position3;
    public GameObject Position4;
    public GameObject Cams;
    public GameObject Cutscenes;
    public GameObject Door;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;


    [SerializeField] private NPCConversation Night5_dialog2;
    //public GameObject GF_glitch_screen;
    public RawImage rawImage;
   // public VideoPlayer videoPlayer;
    public PlayableDirector timelineDirector;
    public static PlayableDirector timelineDirector_static;
    public TimelineAsset glitch_timeline_1;
    public TimelineAsset glitch_timeline_2;
    public TimelineAsset glitch_timeline_3;
    public TimelineAsset glitch_timeline_4;
    public TimelineAsset glitch_timeline_5;
    public TimelineAsset glitch_timeline_6;
    public TimelineAsset glitch_timeline_Rush_hour;
    public static TimelineAsset glitch_timeline_1_static;
    public static TimelineAsset glitch_timeline_2_static;
    public static TimelineAsset glitch_timeline_3_static;
    public static TimelineAsset glitch_timeline_4_static;
    public static TimelineAsset glitch_timeline_5_static;
    public static TimelineAsset glitch_timeline_6_static;
    Jumpscare Jumpscare_script;

    private int random;
    public float rand;
    private static int glitch_screen_random;
    public float jumpscare_cool_down = 20;
    public float jumpscare_time = 3;
    private int Show_position;
    private float escape_time = 1.4f;
    public bool in_process = false;
    private bool jumpscare = true;
    private bool GF_door_position = false;
    private bool GF_tv_position = false;
    private bool GF_bed_position = false;
    private bool GF_trigger_disactivated = false;
    private bool is_GFAO = false;
    private bool stageII_active = false;
    private bool video_running = false;
    private bool glitch_timeline = true;
    public int hour;
    private int chance_of_GFAO = 0;

    void Start()
    {
        timelineDirector_static = timelineDirector;
        glitch_timeline_1_static = glitch_timeline_1;
        glitch_timeline_2_static = glitch_timeline_2;
        glitch_timeline_3_static = glitch_timeline_3;
        glitch_timeline_4_static = glitch_timeline_4;
        glitch_timeline_5_static = glitch_timeline_5;
        glitch_timeline_6_static = glitch_timeline_6;
        Jumpscare_script = GameObject.FindGameObjectWithTag("Manager").GetComponent<Jumpscare>();
        if (timelineDirector != null)
        {
            timelineDirector.stopped += OnTimelineStopped;
        }
        // rawImage.gameObject.SetActive(false); // Ukryj RawImage na pocz¹tku
        //videoPlayer.Stop();
        // videoPlayer.prepareCompleted += OnVideoPrepared;
        // videoPlayer.loopPointReached += EndReached; // Obs³uga zakoñcze
    }

  
    void Update()
    {
        hour = Clock.hour_checker;
        if (hour <= 4 && stageII_active == false) //stageI
        {
            if (gameObject.tag == "hidden" && in_process == false)
            {
                jumpscare_cool_down = 45 - (hour * 7);
                rand = Random.Range(17 - (hour * 3), 20 - (hour * 3));
                in_process = true;
            }
            if (gameObject.tag == "hidden")
            {
                rand = rand - Time.deltaTime;
                if (rand <= 0)
                {
                    Show_position = Random.Range(1, 8);
                    //Show_position =4;
                    if (hour >= 2)
                    {
                        chance_of_GFAO = Random.Range(1, 6 - hour);
                    }
                    if (chance_of_GFAO == 1)
                    {
                        Position_GFAO();
                    }
                    else
                    {
                        Position_normal();
                        //FindObjectOfType<AudioManager>().Play("cupcake_apperance");
                    }
                    gameObject.tag = "show";
                    in_process = false;
                }
            }
            if (gameObject.tag == "show")
            {
                jumpscare_cool_down = jumpscare_cool_down - Time.deltaTime;
                if (jumpscare_cool_down <= 0 && jumpscare == true)
                {
                    //s    Jumpscare_script._Jumpscare("chica");
                    Jumpscare_script._Jumpscare("golden_freddy");
                    FindObjectOfType<AudioManager>().Stop("GF_Stage_I_ambient");
                    FindObjectOfType<AudioManager>().Stop("clock");
                    jumpscare = false;
                    gameObject.SetActive(false);
                }
            }
            if (GF_trigger_disactivated && ((GF_door_position && (door_pos.activeSelf && door_pos_flashlight_status.tag == "flashlight_active")) || (GF_bed_position && bed_pos.activeSelf) || (GF_tv_position && tv_pos.activeSelf)))
            {
                GF_escape();
            }
        }
        else if (stageII_active == false) //stageII
        {
            stageII_active = true;
            GF_trigger_disactivated = false;
            Positions_GFAO.SetActive(false);
            StageII_Plushies.SetActive(true);
            Position_stageII();
            door_position.tag = "0";
            tv_position.tag = "0";
            hide_under_bed_position.tag = "0";
            Position1.SetActive(true);
            Player_Camera.SetActive(true);
            Position2.SetActive(false);
            Position3.SetActive(false);
            Position4.SetActive(false);
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(false);
            Text5.SetActive(false);
            Text6.SetActive(false);
            Cutscenes.SetActive(false);
            Cams.SetActive(false);
            Door.transform.rotation = Quaternion.Euler(0,-5,0);
        }
        else if(stageII_active)  //stageII win-game over checker
        {
            if(hour == 6)
            {
                clock.SetActive(false);
                Jumpscare_script._Jumpscare("golden_freddy");
                Rush_hour.Post_Processing_function();
                gameObject.SetActive(false);
            }
            
        }
        if(hour == 5 && glitch_timeline)
        {
            glitch_timeline = false;
            timelineDirector.playableAsset = glitch_timeline_Rush_hour;
            timelineDirector.Play();
        }
    }
    private void Position_normal()
    {
        switch (Show_position)
        {
            case 1:  
                gameObject.transform.position = Show_door.transform.position;
                gameObject.transform.rotation = Show_door.transform.rotation;
                GF_door_position = true;
                GF_trigger_disactivated = true;
                FindObjectOfType<AudioManager>().Play("door_creaking");
                break;
            case 2:
                gameObject.transform.position = Show_tv.transform.position;
                gameObject.transform.rotation = Show_tv.transform.rotation;
                GF_tv_position = true;
                GF_trigger_disactivated = true;
                FindObjectOfType<AudioManager>().Play("beeping");
                break;
            case 3:
                gameObject.transform.position = Show_bed.transform.position;
                gameObject.transform.rotation = Show_bed.transform.rotation;
                GF_bed_position = true;
                GF_trigger_disactivated = true;
                FindObjectOfType<AudioManager>().Play("whoosh");
                break;
            case 4:
                gameObject.transform.position = Show_bedroom_1.transform.position;
                FindObjectOfType<AudioManager>().Play("whoosh");
                gameObject.transform.rotation = Show_bedroom_1.transform.rotation;
                break;
            case 5:
                gameObject.transform.position = Show_bedroom_2.transform.position;
                gameObject.transform.rotation = Show_bedroom_2.transform.rotation;
                FindObjectOfType<AudioManager>().Play("whoosh");
                break;
            case 6:
                gameObject.transform.position = Show_outside_the_window_1.transform.position;
                gameObject.transform.rotation = Show_outside_the_window_1.transform.rotation;
                FindObjectOfType<AudioManager>().Play("whoosh");
                break;
            case 7:
                gameObject.transform.position = Show_outside_the_window_2.transform.position;
                gameObject.transform.rotation = Show_outside_the_window_2.transform.rotation;
                FindObjectOfType<AudioManager>().Play("whoosh");
                break;
        }
    }
    private void Position_GFAO()
    {
        switch (Show_position)
        {
            case 1:
                GFAO_hallway.SetActive(true);
                GF_door_position = true;
                GF_trigger_disactivated = true;
                is_GFAO = true;
                FindObjectOfType<AudioManager>().Play("gf_glitch_sound");
                break;
            case 2:
                GFAO_bedroom_1.SetActive(true);
                FindObjectOfType<AudioManager>().Play("radio");
                break;
            case 3:
                GFAO_bedroom_2.SetActive(true);
                FindObjectOfType<AudioManager>().Play("gf_glitch_sound");
                break;
            case 4:
                GFAO_bedroom_3.SetActive(true);
                FindObjectOfType<AudioManager>().Play("lamp_flickering");
                break;
            case 5:
                GFAO_outside_the_window_1.SetActive(true);
                FindObjectOfType<AudioManager>().Play("axe_chomp");
                break;
            case 6:
                GFAO_tv.SetActive(true);
                GF_tv_position = true;
                GF_trigger_disactivated = true;
                is_GFAO = true;
                FindObjectOfType<AudioManager>().Play("beeping");
                break;
            case 7:
                GFAO_hallway.SetActive(true);
                GF_door_position = true;
                GF_trigger_disactivated = true;
                is_GFAO = true;
                FindObjectOfType<AudioManager>().Play("gf_glitch_sound");
                break;
        }
    }
    private void Position_stageII()
    {
        Show_position = Random.Range(1, 4);
        switch (Show_position)
        {
            case 1:
           // case 2:
                gameObject.transform.position = StageII_Position1.transform.position;
                gameObject.transform.rotation = StageII_Position1.transform.rotation;
                break;
            case 2:
          //  case 4:
                gameObject.transform.position = StageII_Position2.transform.position;
                gameObject.transform.rotation = StageII_Position2.transform.rotation;
                break;
            case 3:
          //  case 6:
                gameObject.transform.position = StageII_Position3.transform.position;
                gameObject.transform.rotation = StageII_Position3.transform.rotation;
                break;
            case 4:
                gameObject.transform.position = StageII_Position4.transform.position;
                gameObject.transform.rotation = StageII_Position4.transform.rotation;
                break;
        }
    }
    private void GF_escape()
    {
        escape_time -= Time.deltaTime;
        if (escape_time <= 0)
        {
            if (hour != 5)
            {

                gameObject.transform.position = new Vector3(1, 1, 1);
                gameObject.tag = "hidden";
                escape_time = 1.4f;
                if (is_GFAO)
                {
                    GFAO_hallway.SetActive(false);
                    GFAO_tv.SetActive(false);
                    is_GFAO = false;
                }
                GF_bed_position = false;
                GF_door_position = false;
                GF_tv_position = false;
                GF_trigger_disactivated = false;
                glitch_screen_random = Random.RandomRange(1,7);
                Glitch_screen();
                //rawImage.gameObject.SetActive(true); // Poka¿ RawImage
                // videoPlayer.Prepare(); // Odtwórz wideo
            }
            else
            {
                //stage III script
                clock.tag = "2";
                StageII_Plushies.SetActive(false);
                Rush_hour.Post_Processing_function();
                ConversationManager.Instance.StartConversation(Night5_dialog2);
                FindObjectOfType<AudioManager>().Stop_All();
                FindObjectOfType<AudioManager>().Play("win_ringstone");
                gameObject.SetActive(false);

            }

        }
    }
    /* void EndReached(VideoPlayer vp)
     {
         videoPlayer.Stop(); 
         rawImage.gameObject.SetActive(false);
     }
     private void OnVideoPrepared(VideoPlayer vp)
     {
         videoPlayer.Play(); 
     }*/
    public static void Glitch_screen()
    {
        switch (glitch_screen_random)
        {
            case 1:
                timelineDirector_static.playableAsset = glitch_timeline_1_static;
                break;
            case 2:
                timelineDirector_static.playableAsset = glitch_timeline_1_static;
                break;
            case 3:
                timelineDirector_static.playableAsset = glitch_timeline_3_static;
                break;
            case 4:
                timelineDirector_static.playableAsset = glitch_timeline_4_static;
                break;
            case 5:
                timelineDirector_static.playableAsset = glitch_timeline_5_static;
                break;
            case 6:
                timelineDirector_static.playableAsset = glitch_timeline_6_static;
                break;
        }
        FindObjectOfType<AudioManager>().Stop("beeping");
        FindObjectOfType<AudioManager>().Stop("gf_glitch_sound");
        FindObjectOfType<AudioManager>().Mute("GF_Stage_I_ambient");
        timelineDirector_static.Play();
    }
    void OnTimelineStopped(PlayableDirector director)
    {
        FindObjectOfType<AudioManager>().Unmute("GF_Stage_I_ambient");
        timelineDirector_static.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainCamera" && flashlight_status.tag == "flashlight_active"  && GF_trigger_disactivated == false)
        {
            GF_escape();
        }
    }
    private void OnTriggerExit(Collider other)
    {

        escape_time = 1.4f;
    }
}
