using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public class FirstTask : TaskBase
{

    public override void Execute()
    {
        Debug.Write("执行");
    }
    public override void Init()
    {
        relatedTask = new SecondTask();
    }
}