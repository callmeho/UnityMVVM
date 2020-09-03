using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        TaskManager.Instance.InitTaskList();
        PrintTask();
    }
    int id;
    private void OnGUI()
    {
        if(GUILayout.Button("触发"))
        {
            id = Random.Range(0, 10);
            TaskManager.Instance.GetTask(id).taskInfo.CurrState = ETaskState.Triggered;
            PrintTask();
        }
        if (GUILayout.Button("完成"))
        {
            TaskManager.Instance.GetTask("Name" + id).taskInfo.CurrState = ETaskState.Completed;
            PrintTask1();
        }
        if (GUILayout.Button("清空"))
        {
            TaskManager.Instance.ClearTask();
            PrintTask2();
        }
    }

    void OnComplete()
    {

    }
    void PrintTask()
    {
        foreach (TaskBase item in TaskManager.Instance.CurrTaskList)
        {
            Debug.Log(item.taskInfo.Name+"  "+ item.taskInfo.CurrState.ToString() + "  "+item.taskInfo.Describe + "  " + item.taskInfo.TriggerMode);

        }
    }
    void PrintTask2()
    {
        foreach (TaskBase item in TaskManager.Instance.AllTaskList)
        {
            Debug.Log(item.taskInfo.Name + "  " + item.taskInfo.CurrState.ToString() + "  " + item.taskInfo.Describe + "  " + item.taskInfo.TriggerMode);
        }
    }
    void PrintTask1()
    {
        foreach (TaskBase item in TaskManager.Instance.CompletedTaskList)
        {
            Debug.Log(item.taskInfo.Name + "  " + item.taskInfo.CurrState.ToString() + "  " + item.taskInfo.Describe + "  " + item.taskInfo.TriggerMode);
        }
    }
}
