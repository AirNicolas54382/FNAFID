using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatron2_move : MonoBehaviour
{
    private int Show_position;
    public float rand;
    public float jumpscare_cool_down = 20;
    public float jumpscare_time = 3;
    public static bool in_process = false;
    private bool jumpscare = true;
    public GameObject camera;
    public Light light;
    public GameObject flashlight;
    public GameObject Show_1;
    public GameObject Show_2;
    public GameObject Show_3;
    public GameObject Show_4;
    public GameObject Show_5;
    public GameObject Show_6;
    public GameObject Show_7;
    public GameObject Show_8;
    public GameObject Show_9;

    public GameObject GameOver;
    public GameObject chica;
    public GameObject pos1;
    public GameObject jumpscare_pos;
    public GameObject Game_Over_Screen;
    

    Jumpscare Jumpscare_script;

    // private CinemachineImpulseSource impulseSource;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "hidden";
        in_process = false;
        Jumpscare_script = GameObject.FindGameObjectWithTag("Manager").GetComponent<Jumpscare>();
        if (Menu.animatron2_AI == 0)
        {
            gameObject.active = false;
        }
     //   impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "hidden" && in_process == false)
        {
            jumpscare_cool_down = 20;
            rand = Random.Range((30 - Menu.animatron2_AI), (30 - Menu.animatron2_AI) * 2);
            in_process = true;
        }
        if (gameObject.tag == "hidden")
        {
            rand = rand - Time.deltaTime;
            if (rand <= 0)
            {
                Show_position = Random.Range(1, 10);
                switch (Show_position)
                {
                    case 1:
                        gameObject.transform.position = Show_1.transform.position;
                        gameObject.transform.rotation = Show_1.transform.rotation;
                        break;
                    case 2:
                        gameObject.transform.position = Show_2.transform.position;
                        gameObject.transform.rotation = Show_2.transform.rotation;
                        break;
                    case 3:
                        gameObject.transform.position = Show_3.transform.position;
                        gameObject.transform.rotation = Show_3.transform.rotation;
                        break;
                    case 4:
                        gameObject.transform.position = Show_4.transform.position;
                        gameObject.transform.rotation = Show_4.transform.rotation;
                        break;
                    case 5:
                        gameObject.transform.position = Show_5.transform.position;
                        gameObject.transform.rotation = Show_5.transform.rotation;
                        break;
                    case 6:
                        gameObject.transform.position = Show_6.transform.position;
                        gameObject.transform.rotation = Show_6.transform.rotation;
                        break;
                    case 7:
                        gameObject.transform.position = Show_7.transform.position;
                        gameObject.transform.rotation = Show_7.transform.rotation;
                        break;
                    case 8:
                        gameObject.transform.position = Show_8.transform.position;
                        gameObject.transform.rotation = Show_8.transform.rotation;
                        break;
                    case 9:
                        gameObject.transform.position = Show_9.transform.position;
                        gameObject.transform.rotation = Show_9.transform.rotation;
                        break;
                    case 10:
                        gameObject.transform.position = Show_1.transform.position;
                        gameObject.transform.rotation = Show_1.transform.rotation;
                        break;

                }
                FindObjectOfType<AudioManager>().Play("cupcake_apperance");
                gameObject.tag = "show";
                in_process = false;
            }
        }
        if (gameObject.tag == "show")
        {
            jumpscare_cool_down = jumpscare_cool_down - Time.deltaTime;
            if (jumpscare_cool_down <= 0 && jumpscare == true)
            {
                Jumpscare_script._Jumpscare("chica");
                jumpscare = false;
            }
        }
    }
}