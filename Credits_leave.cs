using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_leave : MonoBehaviour
{
    public GameObject Warning_screen;
    public GameObject Warning_menu_transition;
    public GameObject Text;
    private float timer = 3f;
    private bool timer_active = false;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            timer_active = true;
            Text.SetActive(true);
        }
        if (timer_active)
        {
            timer -= Time.deltaTime;
           
            if(timer <= 0)
            {
                timer_active = false;
                timer = 3f;
                Text.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            skip();
        }
    }
    public void skip()
    {
        timer_active = false;
        Warning_menu_transition.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Warning_music");
        Warning_Screen.never_been_here = true;
        Warning_Screen.time_to_enable_click = 10f;
        Warning_screen.SetActive(false);
        Warning_screen.SetActive(true);
        Text.SetActive(false);
        gameObject.SetActive(false);
    }
}
