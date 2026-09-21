using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_smoove : MonoBehaviour
{
    public GameObject EndPos;
    public GameObject flashlight;

    Vector3 endPosition;
    Quaternion  endRotation;

    public float speed = 3;
    public float Timer = 0;
    private bool ismoving = false;
    // Start is called before the first frame update
    void Start()
    {
        // startPositon = transform.position;
        // startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.tag);
        Debug.Log(flashlight.tag);
        Debug.Log(ismoving);

        if (gameObject.tag=="show_stage1" && flashlight.tag=="flashlight_active")
        {
            StartMoving();
        }
            if (ismoving)
            {
                Timer += Time.deltaTime;
                if(Timer > speed)
                {
               

                StopMoving();
                }
                else
                {
                    float ratio = Timer / speed;
                    transform.position = Vector3.Lerp(endPosition, EndPos.transform.position, ratio);
                    transform.rotation = Quaternion.Slerp(endRotation, EndPos.transform.rotation, ratio);
                }
            }
            
        
    }
    private void StartMoving()
    {
        ismoving = true;
        Timer = 0;

        endPosition = transform.position;
        endRotation = transform.rotation;
    }

    private void StopMoving()
    {
        ismoving = false;
        transform.position = EndPos.transform.position;
        transform.rotation = EndPos.transform.rotation;
    }
}
