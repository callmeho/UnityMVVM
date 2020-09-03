using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct TTaskInfo
{
    private string name;
    private int id;
    private string iconName;
    private string describe;
    private  ETaskState currState;
    private  ETaskTriggerMode triggerMode;

    public string Name { get => name; set => name = value; }
    public int Id { get => id; set => id = value; }
    public string Describe { get => describe; set => describe = value; }
    public ETaskState CurrState { get => currState; set => currState = value; }
    public ETaskTriggerMode TriggerMode { get => triggerMode; set => triggerMode = value; }
    public string IconName { get => iconName; set => iconName = value; }
}