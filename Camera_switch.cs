using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_switch : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public Light pos2_light;
    public GameObject pos3;
    public GameObject pos3_tv_component1;
  //  public GameObject pos3_tv_component2;
    public GameObject pos4;
    public GameObject pos1_pos2;
    public GameObject pos2_pos1;
    public GameObject pos1_pos3;
    public GameObject pos3_pos1;
    public GameObject pos1_pos4;
    public GameObject pos4_pos1;

    // Start is called before the first frame update
    void Start()
    {
        pos1.SetActive(true);
        pos2.SetActive(false);
        pos3.SetActive(false);
        pos3_tv_component1.SetActive(false);
      //  pos3_tv_component2.SetActive(false);
        pos4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
   /*     if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            pos1.SetActive(false);
            pos2.SetActive(true);
            pos3.SetActive(false);
            pos3_tv_component1.SetActive(false);
            pos3_tv_component2.SetActive(false);
            pos4.SetActive(false);


        }*/
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (pos2.activeSelf == true)
            {
                pos1_pos2.SetActive(false);
                pos2_pos1.SetActive(true);
                Invoke(nameof(pos2_light_off), 1);
                //  pos1.SetActive(true);
            }
            if (pos3.activeSelf == true)
            {
                pos1_pos3.SetActive(false);
                pos3_pos1.SetActive(true);
            }
            
            if(pos4.activeSelf == true)
            {
                pos1_pos4.SetActive(false);
                pos4_pos1.SetActive(true);
            }

        }
        
        
    }
    private void pos2_light_off()
    {
        pos2_light.intensity = 0;
    }

 
}
