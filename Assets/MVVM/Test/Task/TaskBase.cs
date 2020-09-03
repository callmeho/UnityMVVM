using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class TaskBase : ITask
{
    public TaskBase relatedTask;
    public TTaskInfo taskInfo;

    public event CompleteEvent OnComplete;

    public abstract void Work();

}

public delegate void CompleteEvent();
