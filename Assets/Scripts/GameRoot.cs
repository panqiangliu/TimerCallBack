/*****************************
    文件：GameRoot
    作者：刘攀强
    邮箱：540651527@qq.com 
    日期：2020/2/11
    功能：启动入口
******************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameRoot : MonoBehaviour
{
    public Button Btn;

    void Awake()
    {
        Btn.onClick.AddListener(ClickAddBtn);
    }
    void Start()
    {
        TimerSys timerSys = GetComponent<TimerSys>();
        timerSys.InitSys();
    }

    public void ClickAddBtn()
    {
        Debug.Log("开始生成timerCallBack");
        TimerSys.Instance.AddTimeTask(FunA,2000f);

    }

     void FunA()
    {
        Debug.Log("延迟一段时间后，执行Funa()");
    }

    ///扩展时间单位
    //统一换算成最小的毫秒的时间单位
}
