using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReloadSceneAsync());

        IEnumerator ReloadSceneAsync()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

    }
}
