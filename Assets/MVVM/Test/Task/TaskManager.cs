using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.Util;

public class TaskManager :Singleton<TaskManager> 
{

    private List<TaskBase> allTaskList=new List<TaskBase>();
    private List<TaskBase> currTaskList=new List<TaskBase>();
    private List<TaskBase> completedTaskList=new List<TaskBase>();
    private TaskBase currTask=null;

    public TaskBase CurrTask => currTask;
    public List<TaskBase> CompletedTaskList
    {
        get
        {
            UpdateTaskList();
            return completedTaskList;
        }
    }

    public List<TaskBase> CurrTaskList
    {
        get
        {
            UpdateTaskList();
            return currTaskList;
        }
    }
    public List<TaskBase> AllTaskList => allTaskList;
    void AddTask(TaskBase taskBase,ref List<TaskBase> taskList)
    {
        if (taskList.Contains(taskBase)) return;
        taskList.Add(taskBase);
    }

    public void ClearTask()
    {
        ResetTask();
        currTaskList.Clear();
        completedTaskList.Clear();
    }
    void ResetTask()
    {
        for (int i = 0; i < allTaskList.Count; i++)
        {
            allTaskList[i].taskInfo.CurrState = ETaskState.NonTriggered;
        }
    }
    public void InitTaskList()
    {
        for (int i = 0; i < 10; i++)
        {
            TaskBase task = new HelpPeopleTask();
            task.taskInfo.Id = i;
            task.taskInfo.Name = "Name"+i;
            task.taskInfo.IconName = "IconName"+i;
            task.taskInfo.Describe = "Describe" + i;
            task.taskInfo.CurrState = ETaskState.NonTriggered;
            task.taskInfo.TriggerMode = ETaskTriggerMode.Auto;
            task.relatedTask = new SecondTask();
            allTaskList.Add(task);
        }
    }
    public TaskBase GetTask(string name)
    {
        foreach (TaskBase item in allTaskList)
        {
            if (item.taskInfo.Name == name)
                return item;
        }
        return null;
    }
    public TaskBase GetTask(int id)
    {
        foreach (TaskBase item in allTaskList)
        {
            if (item.taskInfo.Id == id)
                return item;
        }
        return null;
    }
    public void UpdateTaskList()
    {
        foreach (TaskBase item in allTaskList)
        {
            if (item.taskInfo.CurrState == ETaskState.Triggered)
                AddTask(item, ref currTaskList);
        }
        foreach (TaskBase item in currTaskList)
        {
            if(item.taskInfo.CurrState==ETaskState.Completed)
                AddTask(item, ref completedTaskList);
            else if(item.taskInfo.CurrState == ETaskState.Current)
                currTask = item;
        }
    }
}
