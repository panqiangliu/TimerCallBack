/*****************************
    文件：TimerSys
    作者：刘攀强
    邮箱：540651527@qq.com 
    日期：2020/2/11
    功能：计时系统
******************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//支持实现帧定时和时间定时
//支持定时任务的循环，取消和替换
//使用简单，调用方便

public class TimerSys : MonoBehaviour
{
    public static TimerSys Instance;
    //作为一个缓存的list，保存要添加的是事件，当每一帧update开始检验的时候，将缓存的list
    //里边的数据加到热舞list列表里边，刷新新的任务列表之后，对最新的人物列表进行检查
    private List<PETimeTask> tempTimeList = new List<PETimeTask>();
    //定义任务列表
    private List<PETimeTask> taskTimeList = new List<PETimeTask>();
    public void InitSys()
    {
        Instance = this;
        Debug.Log("TimerSys Init Done");
    }

    private void Update()
    {
        //进行检测之前，先将缓存区的数据信息，添加到任务列表之中，然后对列表进行数据处理
        if (tempTimeList.Count > 0)
        {
            for (int index = 0; index < tempTimeList.Count; index++)
            {
                taskTimeList.Add(tempTimeList[index]);
            }
        }
        tempTimeList.Clear();
        //遍历检测任务是否达到进行的条件；
        for (int index = 0; index < taskTimeList.Count; index++)
        {
            PETimeTask timeTask = taskTimeList[index];
            if (timeTask.destTime <= Time.realtimeSinceStartup)
            {
                Action callBack = timeTask.callBack;
                if (callBack != null)
                {
                    callBack();
                }
                //衣橱已经完成的任务
                taskTimeList.RemoveAt(index);
                index--;
            }
        }
    }

    public void AddTimeTask(Action callBack, float delayTime, PetimeUnit timeUnit = PetimeUnit.Millsecond)
    {
        float time = delayTime;
        if (timeUnit != PetimeUnit.Millsecond)
        {
            switch (timeUnit)
            {
                case PetimeUnit.Second:
                    time = time * 1000;
                    break;
                case PetimeUnit.Minute:
                    time = time * 60 * 1000;
                    break;
                case PetimeUnit.Hour:
                    time = time * 60 * 60 * 1000;
                    break;
                case PetimeUnit.day:
                    time = time * 24 * 60 * 60 * 1000;
                    break;
                default:
                    Debug.Log("Add Task TimeUnit Type Error......");
                    break;
            }
        }
        float destTime = Time.realtimeSinceStartup + time;
        PETimeTask timeTask = new PETimeTask
        {
            destTime = destTime,
            callBack = callBack
        };

        tempTimeList.Add(timeTask);
    }




}
