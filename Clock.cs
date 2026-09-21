using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using DialogueEditor;
using UnityEngine.Playables;
//NOTICE: This script is based on an original asset Clock pack from Asset Store, and modify by me to feat game requirements.
public class Clock : MonoBehaviour {

	//-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    public static int hour_checker;
    public int seconds = 0;
	public bool realTime=true;
    public int test;
	
//	public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;
    public GameObject win;
    PlayableDirector director;

    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs=0;

    //--
    [SerializeField] private NPCConversation Night2_5AM;
    [SerializeField] private NPCConversation Bonnie_1;
    [SerializeField] private NPCConversation Bonnie_2;

    private bool Call_once_1 = true;
    private bool Call_once_2 = true;
    private bool Call_once_3 = true;
    private bool broken = false;
    public int night_number;
    private int change_direction_minutes = 1;
    private int change_direction_hour = 1;

    public GameObject door;
    public GameObject Animatronics;
    public GameObject GF;
    public GameObject StageII_Plushies;

    void Start() 
    {
        //-- set real time
        if (realTime)
	{
		hour=System.DateTime.Now.Hour;
		minutes=System.DateTime.Now.Minute;
		seconds=System.DateTime.Now.Second;
	}
        director = GetComponent<PlayableDirector>();
    }

void Update()
    {
        hour_checker = hour;
        if (gameObject.tag == "1") {
            //-- calculate time
        msecs += Time.deltaTime * clockSpeed;
            if (msecs >= 1.0f)
            {
                msecs -= 1.0f;
                seconds++;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                    if (minutes > 60)
                    {
                        minutes = 0;
                        hour++;
                        if (hour >= 24)
                            hour = 0;
                    }
                }
            }
        }else if(gameObject.tag == "2")    //Night5 wygranie Rush hour
        {
            hour = 6;
            minutes = 0;
            seconds = 0;
        }else if(gameObject.tag == "broken")
        {
            broken = true;
            minutes = minutes + change_direction_minutes;
            hour = hour + change_direction_hour;
            if(minutes >= 5000)
            {
                change_direction_hour = -1;
                change_direction_minutes = -1;
            }else if(minutes <= 0)
            {
                change_direction_hour = 1;
                change_direction_minutes = 1;
            }
        }


    //-- calculate pointer angles
    float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
  //  pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

        if (broken == false)
        {
            if (hour == 5 && Menu.Night != 1 && Call_once_1 == true)
            {
                if(Menu.Night == 5)
                {
                    FindObjectOfType<AudioManager>().Stop_All();
                }
                Rush_hour.Rush_hour_function();
                Call_once_1 = false;
                if (Menu.Night == 2)
                {
                    ConversationManager.Instance.StartConversation(Night2_5AM);
                }
                //test = Menu.animatron2_AI;
            }

            if (hour == 2 && minutes == 34 && Menu.Night == 3 && Call_once_2 == true)
            {
                FindObjectOfType<AudioManager>().Stop_All();
                FindObjectOfType<AudioManager>().Play("door_hiting");
                Invoke(nameof(Bonnie_destroying_door), 3);
                Call_once_2 = false;
            }


            if (hour == 6)
            {
                if (Call_once_3 && Menu.Night != 5)
                {
                    FindObjectOfType<AudioManager>().Stop_All();
                    FindObjectOfType<AudioManager>().Play("win_ringstone");
                    Call_once_3 = false;
                }
                if (Menu.Night != 5)
                {
                    Animatronics.SetActive(false);
                    director.Play();

                    win.SetActive(true);
                    // Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;
                    hour = 0;
                }
                gameObject.tag = "0";

            }

        }
}

    public void Bonnie_destroying_door()
    {
        ConversationManager.Instance.StartConversation(Bonnie_1);
        Invoke(nameof(Bonnie_destroying_door2), 10);
        Invoke(nameof(Bonnie_destroying_door3), 35);
        Invoke(nameof(Bonnie_destroying_door5), 40);
    }
    public void Bonnie_destroying_door2()
    {
        FindObjectOfType<AudioManager>().Stop("door_hiting");

    }
    public void Bonnie_destroying_door3()
    {
        FindObjectOfType<AudioManager>().Play("bonnie_roar");
        Invoke(nameof(Bonnie_destroying_door4), 2);
    }
    public void Bonnie_destroying_door4()
    {
        FindObjectOfType<AudioManager>().Play("destroying_door");
    }
    public void Bonnie_destroying_door5()
    {
        ConversationManager.Instance.StartConversation(Bonnie_2);
        door.tag = "1";
    }
}
