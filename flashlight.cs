using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public Light light;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
     


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "broken")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                light.intensity = 2;
                light.tag = "flashlight_active";
            }
            else
            {
                light.intensity = 0;
                light.tag = "flashlight_disactive";
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                source.Play();
            }
        }
    }
}
