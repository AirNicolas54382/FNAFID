using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest_list : MonoBehaviour
{
    private bool check_corridor_task = false;
    private bool check_corridor_task2 = false;
    private bool turn_on_camera_task = false;
    private bool hide_under_the_bed = false;
    private bool pick_up_crowbar = false;
    private bool throw_phone = false;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject flashlight;
    public GameObject clock;
    public GameObject cup_cake;
    public GameObject foxy;
    public GameObject Bonnie;
    public GameObject tv_position;
    public GameObject hide_under_bed_position;
    public GameObject Freddy_dummy;
    public GameObject Crowbar_text;
    public GameObject Crowbar;
    public GameObject Phone_throw;

    [SerializeField] private NPCConversation Bonnie_3;
    [SerializeField] private NPCConversation Bonnie_4;
    [SerializeField] private NPCConversation Night4_dialog2;
    [SerializeField] private NPCConversation Night4_dialog3;
    [SerializeField] private NPCConversation Night5_dialog2_2;
    [SerializeField] private NPCConversation Night5_dialog2_3;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(check_corridor_task == true)
        {
            if(pos2.active == true && flashlight.tag == "flashlight_active")
            {
                ConversationManager.Instance.StartConversation(Bonnie_3);
                check_corridor_task = false;
            }
        }else if(check_corridor_task2 == true)
        {
            if (pos1.active == true)
            {
                ConversationManager.Instance.StartConversation(Bonnie_4);
                check_corridor_task2 = false;
                
            }
        }else if (turn_on_camera_task == true)
        {
            if(pos3.active == true)
            {
                ConversationManager.Instance.StartConversation(Night4_dialog2);
                turn_on_camera_task = false;
                hide_under_the_bed = true;
            }
        }
        else if (hide_under_the_bed == true)
        {
            if (pos4.active == true)
            {
                ConversationManager.Instance.StartConversation(Night4_dialog3);
                hide_under_the_bed = false;
            }
        }
        if(pick_up_crowbar)
        {
            Crowbar_text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                pick_up_crowbar = false;
                ConversationManager.Instance.StartConversation(Night5_dialog2_2);
                Crowbar.SetActive(false);
                Crowbar_text.SetActive(false);
            }
        }
        if (throw_phone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Phone_throw.SetActive(true);
                ConversationManager.Instance.StartConversation(Night5_dialog2_3);
                throw_phone = false;
            }
        }

    }

    public void Night3_disactive_animatronics()
    {
        foxy.SetActive(false);
        cup_cake.SetActive(false);
        clock.tag = "0";
    }
    public void Night3_check_corridor_task()
    { 
        check_corridor_task = true;
    }
    public void Night3_check_corridor_task2()
    {
        check_corridor_task2 = true;
    }
  /*  public void Night3_check_corridor_clock_start()
    {
        Invoke("Night3_check_corridor_clock_start2", 4);
    }
    public void Night3_check_corridor_clock_start2()
    {
        clock.tag = "1";
    }*/
    public void Night3_add_everyone()
    {
        clock.tag = "1";
        Menu.animatron3_AI = 5;
        Bonnie.SetActive(true);
        foxy.SetActive(true);
        FindObjectOfType<AudioManager>().Play("clock");

    }
    public void Night4_turn_on_camera()
    {
        turn_on_camera_task = true;
        tv_position.tag = "1";
        hide_under_bed_position.tag = "1";
        Freddy_dummy.SetActive(true);
    }
    public void stop_calling()
    {

    }
    public void Pick_up_crowbar()
    {
        pick_up_crowbar = true;
    }
    public void Throw_phone()
    {
        throw_phone = true;
    }
}
