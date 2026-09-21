using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class Golden_Freddy_stage_III : MonoBehaviour
{
    public GameObject Hidden;
    public GameObject Show_mirror;
    public GameObject Show_door;
    public GameObject Show_bed1;
    public GameObject Show_bed2;
    public GameObject Show_window1;
    public GameObject Show_window2;
    public GameObject door;
    public GameObject Door_open;
    public GameObject Door_close;
    public GameObject crowbar;
    public GameObject Darell;
    public GameObject shotgun;
    public GameObject atack_text;
    public GameObject finishing_move_timeline;
    public GameObject Crowbar_atack;
    public PlayableDirector playableDirector;
    public Animator anim;
    Jumpscare Jumpscare_script;

    [SerializeField] private NPCConversation Night5_dialog3;

    public float rand;
    public float speed = 1.0f;
    public float jumpscare_cool_down = 10;
    private int show_position;
    public int hp = 3;
    public bool in_process = false;
    public bool jumpscare = true;
    private bool anim_in_progress = false;
    private bool anim_playing_cooldown = false;
    private bool crowbar_atack = false;
    private bool crowbar_atack_ended = false;
    public bool triger_active = true;

    public string animationStateName = "mirror";
    public float frameToCheck = 1.0f;
    private float frameRate = 30.0f;
    BoxCollider box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        box.center = new Vector3(0.9f, 70f, 0f);
        Jumpscare_script = GameObject.FindGameObjectWithTag("Manager").GetComponent<Jumpscare>();
        anim = GetComponent<Animator>();
        crowbar.SetActive(false);
        Darell.SetActive(false);
        shotgun.SetActive(false);
        /* Darell.SetActive(true);
         shotgun.SetActive(true);
         finishing_move_timeline.SetActive(true);*/
        FindObjectOfType<AudioManager>().Play("GF_stageIII_ambient");
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_in_progress)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
            {
                anim.SetInteger("Animation", 0);
                jumpscare = true;
                anim_in_progress = false;
                anim.SetFloat("Animation speed", 1);
                gameObject.transform.position = Hidden.transform.position;
                //anim_playing_cooldown = false;
                gameObject.tag = "hidden";
                box.center = new Vector3(0.9f, 70f, 0f);
            }

            if (Crowbar_atack.activeInHierarchy == false && crowbar_atack_ended)
            {
                crowbar_atack_ended = false;
                gameObject.transform.position = Hidden.transform.position;
                anim_in_progress = false;
                crowbar.SetActive(false);
                jumpscare = true;
                gameObject.tag = "hidden";
                anim.SetInteger("Animation", 0);
                Debug.Log("Crowbar!!!");
                triger_active = true;
            }     
        }

        /* if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && anim.GetCurrentAnimatorStateInfo(0).IsName("crowbar_atack_smaller"))
         {
             crowbar.SetActive(false);
             anim.SetInteger("Animation", 0);
             jumpscare = true;
             anim_back = false;
             gameObject.transform.position = Hidden.transform.position;
             //anim_playing_cooldown = false;
             gameObject.tag = "hidden";  
         }*/


        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("mirror") || first == true)
        //{

        if (gameObject.tag == "hidden" && in_process == false)
            {
            speed = 1;
            switch (hp)
            {
                case 4:
                    jumpscare_cool_down = 15;
                    rand = Random.Range(3, 5);
                    break;
                case 3:
                    jumpscare_cool_down = 10;
                    rand = Random.Range(2, 4);
                    break;
                case 2:
                    jumpscare_cool_down = 10;
                    rand = Random.Range(1, 2);
                    break;
                case 1:
                    jumpscare_cool_down = 7;
                    rand = 1;
                    break;
            }
            // rand = 0.1f;
            in_process = true;
            }
            if (gameObject.tag == "hidden")
            {
            
            rand = rand - Time.deltaTime;
                if (rand <= 0)
                {
                show_position = Random.Range(1, 7);
                //show_position =1;
                
                    Show_position();
                    gameObject.tag = "show";
                    in_process = false;
                  
                }
            }
            //  }
            if (gameObject.tag == "show")
            {
                jumpscare_cool_down = jumpscare_cool_down - Time.deltaTime;
                if (jumpscare_cool_down <= 0 && jumpscare == true)
                {
                Jumpscare_script._Jumpscare("golden_freddy");
                FindObjectOfType<AudioManager>().Stop("GF_stageIII_ambient");
                jumpscare = false;
                }
            }
        if (Input.GetKey(KeyCode.E) && crowbar_atack)
        {
            crowbar.SetActive(true);
            hp--;
            if(hp > 0)
            {
               // anim_playing_cooldown = true;

               // anim.SetBool("crowbar_atack", true);

                atack_text.SetActive(false);
                crowbar_atack = false;
                //anim.SetInteger("Animation", 0);
                jumpscare = false;
                Crowbar_atack.SetActive(true);
                anim_in_progress = true;
                crowbar_atack_ended = true;
                // Invoke(nameof(crowbar_atack_cooldown), 3);

                //gameObject.tag = "hidden";

            }
            else
            {
                //  anim_playing_cooldown = true;
                FindObjectOfType<AudioManager>().Stop_All();
                atack_text.SetActive(false);
                Darell.SetActive(true);
                shotgun.SetActive(true);
                finishing_move_timeline.SetActive(true);
                gameObject.tag = "deactivated";
            }
        }
    }
    private void Show_position()
    {
        switch (show_position)
        {
            case 1:
                anim.SetInteger("Animation", 1);
                gameObject.transform.position = Show_mirror.transform.position;
                gameObject.transform.rotation = Show_mirror.transform.rotation;
                crowbar_atack = true;
                triger_active = false;
                atack_text.SetActive(true);
                break;
            case 2:
                anim.SetInteger("Animation", 2);
                gameObject.transform.position = Show_door.transform.position;
                gameObject.transform.rotation = Show_door.transform.rotation;
                Door_open.SetActive(true);
                Door_close.SetActive(false);
                FindObjectOfType<AudioManager>().Play("door_open");
                break;
            case 3:
                anim.SetInteger("Animation", 3);
                gameObject.transform.position = Show_bed1.transform.position;
                gameObject.transform.rotation = Show_bed1.transform.rotation;
                box.center = new Vector3(0f, 120f, 0f);
                break;
            case 4:
                anim.SetInteger("Animation", 4);
                gameObject.transform.position = Show_bed2.transform.position;
                gameObject.transform.rotation = Show_bed2.transform.rotation;
                box.center = new Vector3(0f, 120f, 0f);
                break;
            case 5:
                anim.SetInteger("Animation", 5);
                gameObject.transform.position = Show_window1.transform.position;
                gameObject.transform.rotation = Show_window1.transform.rotation;
                box.center = new Vector3(-75f, 70f, 0f);

                break;
            case 6:
                anim.SetInteger("Animation", 6);
                gameObject.transform.position = Show_window2.transform.position;
                gameObject.transform.rotation = Show_window2.transform.rotation;
                box.center = new Vector3(75f, 70f, 0f);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "show" && triger_active)
        {
            jumpscare = false;
            if (show_position == 2)
            {
                Door_open.SetActive(false);
                Door_close.SetActive(true);
                FindObjectOfType<AudioManager>().Play("door_close");
            }
            speed = -1;
            //anim_playing_cooldown = true;
            anim.SetFloat("Animation speed", speed);
            anim_in_progress = true;
        }

    }
    private void crowbar_atack_cooldown()
    {
        //anim_playing_cooldown = false;

    }
    /*
    void OnGUI()
    {
       speed = EditorGUILayout.Slider("Animation speed", speed, -1, 1);
    }
    */
}
