using UnityEngine;
using System.Collections;
//文件名：        CharacterModel.cs
//作者：            MQ
//编写日期：      2015-8-17
//描述：               加载所有可升级武器图片

public class NetTick : MonoBehaviour {

    public static NetTick ShareTick
    {
        get
        {
            if ( _tick == null)
            {
                GameObject obj = new GameObject("NetTick");
                _tick = obj.AddComponent<NetTick>();
               DontDestroyOnLoad(obj);
            }
            return _tick;
        }
        
    }

    private static NetTick _tick;

    private float time;
    private bool isTicking;
    
    public delegate void  DelegateEvent();
    public DelegateEvent   TimeUpEvent;

    public DelegateEvent   StopEvent;

    public void SetTime( float tickTime)
    {
        time = tickTime;
    }

    public void StartTick(float time)
    {
        this.time = time;
        isTicking = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (isTicking)
        {
            time -= time - Time.deltaTime;
            if (time <= 0)
            {
                this.TimeUp();
            }
        }
	}



    public bool IsTicking()
    {
        return  this.isTicking;
    }

    public void Stop()
    {
        this.ResetTime();
        StopEvent();
    }

    private void ResetTime()
    {
        isTicking = false;
        time = 0;
    }

    private void TimeUp()
    {
        this.ResetTime();
        TimeUpEvent();
    } 

    

}
