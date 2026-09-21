using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
    public AudioSource source;
    bool playing = false;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (playing == false)
            {
                source.Play();
                playing = true;
            }else if(playing){
                source.Stop();
                playing = false;
            }
        }
    }
}
