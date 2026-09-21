using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Target_see : MonoBehaviour
{
    public Collider collider;
    public GameObject flashlight_status;
    public float escape_time = 1.4f;
    public Animator anim;
    public GameObject dialogues;
    [SerializeField] private NPCConversation Night1_cupcake_defend;
    private bool cupcake_first_defend_reaction = true;
    private bool on_cupcake = false;
    public Animator transition;
    private PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        // anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }



    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Target_see", true);
        on_cupcake = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainCamera" && flashlight_status.tag == "flashlight_active")
        {
           // anim.SetBool("Transition", false);
            FindObjectOfType<AudioManager>().Stop("cupcake_apperance");
            if (on_cupcake == true)
            {
                FindObjectOfType<AudioManager>().Play("whoosh");
                on_cupcake = false;
            }
            escape_time -= Time.deltaTime;
            if(escape_time <= 0)
            {
                // anim.SetBool("Transition", true);
                director.Play();
                gameObject.transform.position = new Vector3(1, 1, 1);
                gameObject.tag = "hidden";
                if (Menu.Night == 1 && cupcake_first_defend_reaction == true)
                {
                    ConversationManager.Instance.StartConversation(Night1_cupcake_defend);
                    cupcake_first_defend_reaction = false;
                }
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("whoosh");
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        on_cupcake = false;
        anim.SetBool("Target_see", false);
        escape_time = 1.4f;
    }
}
