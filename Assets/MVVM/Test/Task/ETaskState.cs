using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum ETaskState
{
    NonTriggered=0,  //未触发
    Triggered=1,     //已触发
    Current=2,       //正在进行
    Completed=3,     //已完成
}