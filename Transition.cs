using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static IEnumerator LoadLevel()
    {
        //   anim.SetBool("Transition", true);
        anim.SetBool("Transition", true);
        yield return new WaitForSeconds(3);
        //anim.SetBool("Transition", false);
        SceneManager.LoadScene("Game");

    }
}
