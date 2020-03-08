/*****************************
    PETimeTask
    作者：刘攀强
    邮箱：540651527@qq.com 
    日期：2020/2/11
    功能：定时任务数据类
******************************/
using System;

public class PETimeTask 
{
	//延迟任务的时间
	public float destTime;
	//要运行什么样的任务
	public Action callBack;
	
}
//时间的运行单位
public enum PetimeUnit
{
    Millsecond,
    Second,
    Minute,
    Hour,
    day
}
