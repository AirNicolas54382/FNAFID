using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscenes_braker : MonoBehaviour
{
    public GameObject pos2_pos1;
    public GameObject pos3_pos1;
    public GameObject pos4_pos1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pos2_pos1.activeSelf == true)
        {
            pos2_pos1.SetActive(false);
        }
        if (pos3_pos1.activeSelf == true)
        {
            pos3_pos1.SetActive(false);
        }
        if (pos4_pos1.activeSelf == true)
        {
            pos4_pos1.SetActive(false);
        }
    }
}
