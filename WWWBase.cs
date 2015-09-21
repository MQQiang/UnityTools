using UnityEngine;
using System.Collections;

public abstract class WWWBase {

     public   delegate void DataBackMethod();
    public DataBackMethod DataBackEvent;

    public string Url
    {
        get;
        set;
    }
    public WWWForm Form
    {
        get;
        set;
    }
   
    public IEnumerator ProcessUrl(string url, WWWForm form)
    {
        this.Url = url;
        this.Form = form;



        WWW   www = new WWW(url,form);
        yield return www;

        if (www.error != null)
        {
            DealNetError();
        }
        else
        {
            DataBackEvent();
            DealBackData(www.text);
        }
    }

    public void DealNetError()
    {
        
    }

    public abstract void DealBackData(string data);


}
