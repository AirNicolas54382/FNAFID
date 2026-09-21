using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock_broken : MonoBehaviour
{
    public GameObject clock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock.tag = "broken";
    }
}
