using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_GF_Night : MonoBehaviour
{
    public static bool ending_credits = false;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Menu.writer.Write("Star_2", true).Commit();
        ending_credits = true;
        SceneManager.LoadScene("Menu");
    }
}
