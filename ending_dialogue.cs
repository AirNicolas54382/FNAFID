using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending_dialogue : MonoBehaviour
{
    [SerializeField] private NPCConversation Night5_dialog3;
    public GameObject Finishing_move;
    // Start is called before the first frame update
    void Start()
    {
        Finishing_move.SetActive(false);
        ConversationManager.Instance.StartConversation(Night5_dialog3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
