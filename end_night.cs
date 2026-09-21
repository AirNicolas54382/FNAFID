using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_night : MonoBehaviour
{
    public GameObject End_Night_Screen;
    //private int Night;
    // Start is called before the first frame update
    void Start()
    {
        End_Night_Screen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Menu.reader.Reload();
            Menu.Night = Menu.reader.Read<int>("Night");
            Debug.Log("Przed zapisem game: Night = " + Menu.Night);
            if (Menu.Night == 4)
            {
                Menu.writer.Write("Star_1", true).Commit();
            }
            else if (Menu.Night == 6 && Menu.animatron1_AI >= 20 && Menu.animatron2_AI >= 20 && Menu.animatron3_AI >= 20 && Menu.animatron4_AI >= 20)
            {
                //Menu.custom_night = false;
                Menu.writer.Write("Star_3", true).Commit();
            }
            Menu.Night += 1;
            if(Menu.Night > 5)
            {
                Menu.Night = 5;
            }
            Menu.writer.Write("Night", Menu.Night).Commit();
            Debug.Log("Po zapisie game: Night = " + Menu.Night);
            SceneManager.LoadScene("Menu");
        }
    }
}
