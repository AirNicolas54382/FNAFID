using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GFAO_seen : MonoBehaviour
{
    public float escape_time = 1.4f;
    public GameObject flashlight_status;
    public GameObject GF_Plushy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainCamera" && flashlight_status.tag == "flashlight_active")
        {
            escape_time -= Time.deltaTime;
            if (escape_time <= 0)
            {
                Golden_Freddy_stage_I.Glitch_screen();             
                escape_time = 1.4f;
                GF_Plushy.tag = "hidden";
                gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Stop("radio");
                FindObjectOfType<AudioManager>().Stop("lamp_flickering");
                FindObjectOfType<AudioManager>().Stop("gf_glitch_sound");
            }

        }
    }
   
}
