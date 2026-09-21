using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System;

public class Animatron1_move_back : MonoBehaviour
{
    public Collider collider;
    public GameObject flashlight_status;
    public GameObject EndPos;

    Vector3 endPosition;
    Quaternion endRotation;

    public float speed = 1;
    public float Timer = 0;
    private bool ismoving = false;
    private bool foxy_first_defend_reaction = true;
    public Animator anim;

    [SerializeField] private NPCConversation Night2_foxy_defend;

    public 


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
        if (other.tag == "MainCamera" && flashlight_status.tag == "flashlight_active" && gameObject.tag != "hidden")
        {
            anim.SetBool("Show", false);
            gameObject.tag = "hidden";
            if (Menu.Night == 2 && foxy_first_defend_reaction == true)
            {
                ConversationManager.Instance.StartConversation(Night2_foxy_defend);
                foxy_first_defend_reaction = false;
            }
        }
    }
}
