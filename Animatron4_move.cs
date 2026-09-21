using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animatron4_move : MonoBehaviour
{
    public static string position = "Start_Room";
    public float Interval_move = 10f;
    public int AI_level = 0;
    public int random = 0;

    public GameObject Start_Room;
    public GameObject Room_1;
    public GameObject Room_2;
    public GameObject Room_3;
    public GameObject Room_4;
    public GameObject Room_5;
    public GameObject Room_6;
    public GameObject Vent_1;
    public GameObject Vent_2;
    public GameObject Vent_3;
    public GameObject Vent_4;
    public GameObject Hidden;
    public GameObject Jumpscare;
    public GameObject new_position;

    public GameObject Hallway1;
    public GameObject Hallway2;
    public GameObject Hallway3;
    public GameObject Hallway4;
    public GameObject Hallway5;
    public GameObject Vent1;
    public GameObject Vent2;
    public GameObject Vent3;
    public GameObject Vent4;

    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        AI_level = Menu.animatron4_AI;
        gameObject.tag = "1"; // in room
        if (AI_level == 0)
        {
            gameObject.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "0")
        {
            position = "Start_Room";
            gameObject.transform.position = Start_Room.transform.position;
            Interval_move = 10f;
            gameObject.tag = "1";
        }
        Interval_move -= Time.deltaTime;
        if (Interval_move <= 0)
        {
            Interval_move = 10f;
            random =UnityEngine.Random.Range(1, 31);
            if (random <= AI_level)
            {
                Animatron_Move();
            }
        }
    }

    private void Animatron_Move()
    {
        gameObject.tag = "1";
        random = UnityEngine.Random.Range(1, 5);
        switch (position)
        {
                
            case "Start_Room": //25%;50%;25%
                if (random == 1)
                {
                    position = "Room_1";
                    new_position = Room_1;
                }else if (random == 2 || random==3)
                {
                    if (Hallway1.tag == "opened")
                    {
                        position = "Room_3";
                        new_position = Room_3;
                    }
                    else
                    {
                        Animatron_Move();
                    }
                }
                else
                {
                    position = "Room_2";
                    new_position = Room_2;
                }
                break;
            case "Room_1": //25%;75%;
                if (random == 1)
                {
                    position = "Vent_1";
                    new_position = Vent_1;
                    gameObject.tag = "2";
                }
                else
                {
                    position = "Start_Room";
                    new_position = Start_Room;
                }
                break;
            case "Room_2"://25%;75%;
                if (random == 1)
                {
                    position = "Vent_3";
                    new_position = Vent_3;
                    gameObject.tag = "2";
                }
                else
                {
                    position = "Start_Room";
                    new_position = Start_Room;
                }
                break;
            case "Room_3"://25%;25%;25%;25%;
                if (random == 1)
                {
                    if (Hallway2.tag == "opened")
                    {
                        position = "Room_4";
                        new_position = Room_4;
                    }
                    else
                    {
                        Animatron_Move();
                    }
                }else if(random == 2)
                {
                    position = "Vent_2";
                    new_position = Vent_2;
                    gameObject.tag = "2";
                }
                else if(random == 3)
                {
                    if (Hallway3.tag == "opened")
                    {
                        position = "Room_5";
                        new_position = Room_5;
                    }
                    else
                    {
                        Animatron_Move();
                    }
                }
                else
                {
                    if (Hallway1.tag == "opened")
                    {
                        position = "Start_Room";
                        new_position = Start_Room;
                    }
                    else
                    {
                        Animatron_Move();
                    }
                }
                break;
            case "Room_4"://50%;50% 
           
                if (random == 1 || random == 2)
                {
                    if (Hallway4.tag == "opened")
                    {
                        position = "Room_6";
                        new_position = Room_6;
                    }
                    else
                    {
                        Animatron_Move();
                    }

                }
                else if(random == 3 || random == 4)
                {
                    if (Hallway2.tag == "opened")
                    {
                        position = "Room_3";
                        new_position = Room_3;
                    }
                    else
                    {
                        Animatron_Move();
                    }
                }
                break;
            case "Room_5"://50%;50%
                if (random == 1 || random == 2)
                {
                    if (Hallway5.tag == "opened")
                    {
                        position = "Room_6";
                        new_position = Room_6;
                    }
                    else
                    {
                        Animatron_Move();
                    }

                }
                else if (random == 3 || random == 4)
                {
                    if (Hallway3.tag == "opened")
                    {
                        position = "Room_3";
                        new_position = Room_3;
                    }
                    else
                    {
                        Animatron_Move();
                    }
                }
                break;
            case "Room_6"://100%       
                    position = "Vent_4";
                    new_position = Vent_4;
                   gameObject.tag = "2";
                break;
            case "Vent_1"://100%
                    position = "Room_4";
                    new_position = Room_4;
                
                break;
            case "Vent_2"://100%
                position = "Room_6";
                new_position = Room_6;
             
                break;
            case "Vent_3"://100%
                position = "Room_5";
                new_position = Room_5;
               
                break;
            case "Vent_4"://100%
                position = "Jumpscare";
                new_position = Jumpscare;
                GameOver.SetActive(true);
                Time.timeScale = 0;

                break;
            case "Hidden"://100%
                position = "Start_Room";
                new_position = Start_Room;
                break;
        }
        gameObject.transform.position = new_position.transform.position;
    }
}
