using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open_close : MonoBehaviour
{
    public GameObject door;
    public GameObject pos2;
    public GameObject cutscene;
    public GameObject Door_open;
    public GameObject Door_close;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pos2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Door_open.SetActive(false);
                Door_close.SetActive(true);
                FindObjectOfType<AudioManager>().Play("door_close");
            }
            else if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                Door_close.SetActive(false);
                Door_open.SetActive(true);
                FindObjectOfType<AudioManager>().Play("door_open");

            }

        }
    }
}
