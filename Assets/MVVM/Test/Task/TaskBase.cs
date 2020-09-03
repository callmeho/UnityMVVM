using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class TaskBase : ITask
{
    public TaskBase relatedTask;
    public TTaskInfo taskInfo;
    private bool isActive=false;
    private bool isTriggered = false;
    private bool isComplete=false;

    public event CompleteEvent OnComplete = null;


    public bool IsTriggered
    {
        get => isTriggered;
        set
        {
            isTriggered = value;
            if (isTriggered)
                taskInfo.CurrState = ETaskState.Triggered;
            else
                taskInfo.CurrState = ETaskState.NonTriggered;
        }
    }
    public bool IsComplete 
    {
        get => isComplete;
        set
        {
            isComplete = value;
            if (!isTriggered)
                isComplete = false;
            if (isComplete)
            {
                taskInfo.CurrState = ETaskState.Completed;
                OnComplete?.Invoke();
            }
        }
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
    public abstract void Execute();
    public virtual void Init() { }

    
}

public delegate void CompleteEvent();
