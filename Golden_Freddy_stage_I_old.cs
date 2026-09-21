using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golden_Freddy_stage_I_old : MonoBehaviour
{
    public GameObject animatron1;
    public GameObject animatron2;
    public GameObject animatron3;
    public GameObject animatron4;
    public GameObject GF_Plush;
    public GameObject Task_1;
    public GameObject Task_2;
    public GameObject Task_3;
    public GameObject Task_4;
    public GameObject Task_5;
    private int task_number;
    private ArrayList tasks_list;
    private int random;
    private string task;

    void Start()
    {
        tasks_list.Add("Task_1");
        tasks_list.Add("Task_2");
        tasks_list.Add("Task_3");
        tasks_list.Add("Task_4");
        tasks_list.Add("Task_5");
        task_number = 1;
        Task(task_number);
    }

  
    void Update()
    {
    }
    private void Task(int task_number)
    {
        random = Random.Range(0,tasks_list.Count);
        task = tasks_list[random].ToString();
        tasks_list.RemoveAt(random);
        switch (task)
        {
            case "Task_1":
                Task_1.SetActive(true);
                break;
            case "Task_2":
                Task_2.SetActive(true);
                break;
            case "Task_3":
                Task_3.SetActive(true);
                break;
            case "Task_4":
                Task_4.SetActive(true);
                break;
            case "Task_5":
                Task_5.SetActive(true);
                break;
        }
    }
}
