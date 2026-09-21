using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Position : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject PlayerCamera;
    public GameObject Pos2_Camera;
    public GameObject Pos3_Camera;
    public GameObject Pos4_Camera;
    public GameObject icon;
    public GameObject flashlight_status;
    public GameObject pos1;
    public GameObject hide_under_the_bed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(pos1.active == false)
        {
            icon.SetActive(false);
        }
    }
    



    private void OnTriggerStay(Collider other)
    {
        if (flashlight_status.tag == "flashlight_active" && hide_under_the_bed.tag == "1")
        {
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
        if (other.tag == "MainCamera" && gameObject.tag == "1")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                PlayerCamera.SetActive(false);
                Pos2_Camera.SetActive(false);
                Pos3_Camera.SetActive(false);
                Pos4_Camera.SetActive(false);       
                cutscene.SetActive(true);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        icon.SetActive(false);
    }
}
