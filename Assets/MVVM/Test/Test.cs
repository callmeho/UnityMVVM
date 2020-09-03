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
            TaskManager.Instance.GetTask(id).IsTriggered = true;
            PrintTask();
        }
        if (GUILayout.Button("完成"))
        {
            TaskManager.Instance.GetTask(id).OnComplete += OnComplete;
            TaskManager.Instance.GetTask("Name" + id).IsComplete = true;
            PrintTask1();
        }
        if (GUILayout.Button("清空"))
        {
            TaskManager.Instance.ClearTask();
            PrintTask2();
        }
        if (GUILayout.Button("激活"))
        {
            TaskManager.Instance.GetTask(id).IsActive = true;
            PrintTask2();
        }
    }

    void OnComplete()
    {
        Debug.LogError("完成");
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
