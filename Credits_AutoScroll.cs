using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 20f;
  

    void Update()
    {
        scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;
        if (scrollRect.verticalNormalizedPosition <= 0)
        {
            scrollRect.verticalNormalizedPosition = 1;
        }
    }
}
