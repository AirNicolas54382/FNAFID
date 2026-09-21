using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Animatron3_move : MonoBehaviour
{
    public float rand;
    public float stage1;
    public float jumpscare_cool_down;
    public float jumpscare_time = 3;
    public static bool in_process = false;
    public Camera Game_Over_Camera;
    public Light Game_Over_Light;
    public GameObject flashlight;
    public GameObject far_away;
    public GameObject At_the_door;
    public AudioSource breath;
    public GameObject GameOver;
    public GameObject Stage1;
    public GameObject Stage2;
    public float Time_animatron3_leave_door = 3;
    public GameObject door;
    public GameObject pos2;
    public bool playsound = true;
    public GameObject test;

    public AudioSource bong;

    public GameObject EndPos;

    Vector3 endPosition;
    Quaternion endRotation;

    public float speed = 3;
    public float Timer = 0;
    private bool ismoving = false;

    public Animator anim;

    public GameObject bonnie;
    public GameObject pos1;
    public GameObject jumpscare_pos;
    public GameObject Game_Over_Screen;

    public GameObject jumpscare_timeline;

    Jumpscare Jumpscare_script;

    bool jumpscare = true;

    public GameObject door_closed_bool;

    public TMP_Text bonnie_movement;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "hidden";
        in_process = false;
        Jumpscare_script = GameObject.FindGameObjectWithTag("Manager").GetComponent<Jumpscare>();
        if (Menu.animatron3_AI == 0)
        {
            gameObject.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------Animatron hidden-------------------------
        if (gameObject.tag == "hidden" && in_process == false)
        {

            jumpscare_cool_down = 30 - Menu.animatron3_AI;
            rand = Random.Range((30 - Menu.animatron3_AI), (30 - Menu.animatron3_AI) * 2);
            stage1 = 0;
            Time_animatron3_leave_door = 3;
            in_process = true;
        }
        if (gameObject.tag == "hidden")
        {
            rand = rand - Time.deltaTime;
            if (rand <= 0)
            {
                anim.SetBool("Show", true);
                gameObject.transform.position = far_away.transform.position;
                gameObject.transform.rotation = far_away.transform.rotation;
                gameObject.tag = "show_stage1";
                in_process = false;
            }
        }
        //--------------------Stage1 -------------------------
        if (gameObject.tag == "show_stage1" && in_process == false)
        {
            stage1 = Random.Range((30 - Menu.animatron3_AI), (30 - Menu.animatron3_AI) * 2);
            in_process = true;
            // Stage1.SetActive(true);
        }
        if (gameObject.tag == "show_stage1")
        {
            stage1 = stage1 - Time.deltaTime;
            //--------------------Target_See_system -------------------------
            if (flashlight.tag == "flashlight_active" && pos2.activeSelf)
            {
                anim.SetBool("Show", false);
                gameObject.tag = "hidden";
                rand = 0;
                stage1 = 1;
                in_process = false;
            }
            if (stage1 <= 0)
            {
                gameObject.transform.position = At_the_door.transform.position;
                gameObject.transform.rotation = At_the_door.transform.rotation;
                gameObject.tag = "show_stage2";
                in_process = false;
            }
        }
        //--------------------Stage2 -------------------------
        if (gameObject.tag == "show_stage2")
        {
            if(door_closed_bool.active == false)
            {
                jumpscare_cool_down = jumpscare_cool_down - Time.deltaTime;
                Time_animatron3_leave_door = 3;
                if (pos2.activeSelf && playsound == true)
                {
                    breath.Play();
                    playsound = false;
                }
            }
           
            if (flashlight.tag == "flashlight_active" && door_closed_bool.active == false && jumpscare == true && pos2.activeSelf)
            {
                Jumpscare_script._Jumpscare("bonnie");
                jumpscare = false;
            }
            if (door_closed_bool.active == true)
            {
                playsound = true;
                breath.Stop();
                Time_animatron3_leave_door -= Time.deltaTime;
                if (Time_animatron3_leave_door <= 0)
                {
                    bong.Play();
                    gameObject.transform.position = new Vector3(1, 1, 1);
                    gameObject.tag = "hidden";
                   // playsound = true;

                }
            }

            if (jumpscare_cool_down <= 0 && jumpscare == true)//--------------------JumpScare -------------------------
            {
                Jumpscare_script._Jumpscare("bonnie");
                jumpscare = false;
            }
               
                

            
        }
        if(pos2.activeSelf == false)
        {
            flashlight.tag = "flashlight_disactive";
        }
        bonnie_movement.text = "Bonnie_timer: " + stage1;
    }

   
}