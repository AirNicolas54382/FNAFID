using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Animatron1_move : MonoBehaviour
{
    public float rand;
    public float jumpscare_cool_down = 20;
    public static bool in_process = false;
    private bool jumpscare = true;
    public GameObject camera;
    public Light light;
    public GameObject flashlight;
    public GameObject GameOver;
    public GameObject Pos1;
    public Animator anim;
   

    Jumpscare Jumpscare_script;

    public TMP_Text foxy_movement;


    // Start is called before the first frame update
    void Start()
    {
        in_process = false;
        gameObject.tag = "hidden";
        Jumpscare_script = GameObject.FindGameObjectWithTag("Manager").GetComponent<Jumpscare>();
        if(Menu.animatron1_AI == 0)
        {
            gameObject.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "hidden" && in_process == false)
        {
            jumpscare_cool_down = 20;
            rand = Random.Range((30 - Menu.animatron1_AI), (30 - Menu.animatron1_AI) * 2);
            in_process = true;
        }
        if (gameObject.tag == "hidden")
        {
            rand = rand - Time.deltaTime;
            if (rand <= 0)
            {
                anim.SetBool("Show", true);
               // transform.position = Pos1.transform.position;
                gameObject.transform.rotation = Pos1.transform.rotation;
                gameObject.tag = "show";
                in_process = false;
            }
        }
        if(gameObject.tag == "show")
        {
            jumpscare_cool_down = jumpscare_cool_down - Time.deltaTime;
            if (jumpscare_cool_down <= 0 && jumpscare == true)
            {
                Jumpscare_script._Jumpscare("foxy");
                jumpscare = false;
            }
        }
        foxy_movement.text = "Foxy_timer: " + rand;
    }
}
