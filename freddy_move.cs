using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class freddy_move : MonoBehaviour
{
    private static string Freddy_tag;
    public int stage_counter = 0;
    private string[] stages = { "deactivated", "show_stage1", "show_stage2", "show_stage3", "hidden", "show", "jumpscare"};
    public GameObject pos3;
    public GameObject pos4;
    public GameObject Freddy;
    public GameObject shed_pos;
    public GameObject stage3_pos;
    public GameObject bedroom_pos;
    public GameObject hidden_pos;
    public float timer = 5;
    public float cutscene_timer = 15f;
    public float cutscene_gap = 0f;
    private bool cutscene = false;
    private bool chica = false;
    private bool bonnie = false;
    private bool foxy = false;
    private bool cutscene_activator1 = true;
    private bool cutscene_activator2 = true;
    private float cant_stop_freddy_brackets_time = 10;
    private bool cant_stop_freddy_brackets = false;
    public Animator anim;
    public GameObject Bedroom_cutscene;
    public GameObject Foxy;
    public GameObject Chica;
    public GameObject Bonnie;
    public GameObject Manager;
    public GameObject Freddy_dummy;
    public GameObject Foxy_hidden_position;
    public GameObject Bonnie_hidden_position;

    Jumpscare Jumpscare_script;

    public TMP_Text fr_movement;
    public TMP_Text fr_stage;


    void Start()
    {
        Freddy.tag = "deactivated";
        stage_counter = 0;
        gameObject.transform.position = shed_pos.transform.position;
        gameObject.transform.rotation = shed_pos.transform.rotation;
        if(Menu.Night == 4)
        {
            Freddy_dummy.SetActive(false);
        }
        Jumpscare_script = GameObject.FindGameObjectWithTag("Manager").GetComponent<Jumpscare>();
        if (Menu.animatron4_AI == 0)
        {
            gameObject.active = false;
        }
        timer = Random.Range((30 - Menu.animatron4_AI), (30 - Menu.animatron4_AI) * 2);
    }
    void Update()
    {
        if ((pos3.active == false && cutscene == false)||(pos3.active == true && timer <= 10 && stage_counter < 2))
        {
            Stage_Counter(Freddy.tag);
        }
        if(pos4.active==true && Freddy.tag == "hidden")
        {
            cutscene = true;
            stage_counter = 5;
            Move(stage_counter);
            Cutscene();
        }
        fr_movement.text = "Fr_timer: " + timer;
        fr_stage.text = "Fr_stage: " + stage_counter;
    }

    private void Stage_Counter(string Freddy_tag)
    {
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stage_counter++;
            Move(stage_counter);   
            Freddy.tag = stages[stage_counter];
            if(stage_counter == 4)
            {
                timer = Random.Range(30- Menu.animatron4_AI, (30- Menu.animatron4_AI) +10);
            }
            else
            {
                timer = Random.Range((30 - Menu.animatron4_AI), (30 - Menu.animatron4_AI) * 2);
            }
            
          
        }

    } 

    private void Move(int stage)
    {
        switch (stage)
        {
            case 0:
                gameObject.transform.position = shed_pos.transform.position;
                gameObject.transform.rotation = shed_pos.transform.rotation;
                break;
            case 1:
                anim.SetBool("stage0", false);
                anim.SetBool("stage1", true);
                break;
            case 2:
                anim.SetBool("stage2", true);
                break;
            case 3:
                gameObject.transform.position = stage3_pos.transform.position;
                gameObject.transform.rotation = stage3_pos.transform.rotation;
                break;
            case 4:
                gameObject.transform.position = hidden_pos.transform.position;
                break;
            case 5:
                if (pos4.activeSelf)
                {
                    gameObject.transform.position = bedroom_pos.transform.position;
                    Bedroom_cutscene.SetActive(true);
                    Manager.GetComponent<Camera_switch>().enabled = false;
                }
                else
                {
                    Jumpscare_script._Jumpscare("freddy");
                }
                break;
        }
    }

    private void Cutscene()
    {//0.4 ligth
        if (Foxy.activeSelf)
        {
            Foxy.SetActive(false);
            foxy = true;
        }
        if (Chica.activeSelf)
        {
            FindObjectOfType<AudioManager>().Stop("cupcake_apperance");
            Chica.SetActive(false);
            chica = true;
        }
        if (Bonnie.activeSelf)
        {
            Bonnie.SetActive(false);
            bonnie = true;
        }
            cutscene_timer -= Time.deltaTime;
            if (cutscene_timer <= 0)
            {
                Bedroom_cutscene.SetActive(false);
                Manager.GetComponent<Camera_switch>().enabled = true;
                anim.SetBool("stage0", true);
                anim.SetBool("stage1", false);
                anim.SetBool("stage2", false);
                stage_counter = 0;
                Move(stage_counter);
                timer = Random.Range((30 - Menu.animatron4_AI), (30 - Menu.animatron4_AI) * 2);
                Freddy.tag = stages[stage_counter];
                cutscene = false;
                if (foxy)
                {
                Foxy.tag = "hidden";
                Foxy.SetActive(true);
                Foxy.transform.position = Foxy_hidden_position.transform.position;
                Animatron1_move.in_process = false;               
                    foxy = false;
                }
                if (chica)
                {
                Chica.tag = "hidden";
                Chica.SetActive(true);
                Animatron2_move.in_process = false;
                Chica.transform.position = new Vector3(1, 1, 1);
                chica = false;
                }
                if (bonnie)
                {
                Bonnie.tag = "hidden";
                Bonnie.SetActive(true);
                Animatron3_move.in_process = false;
                Bonnie.transform.position = Bonnie_hidden_position.transform.position;
                bonnie = false;
                }
                cutscene_timer = 15f;
            }
        }
        
    }

