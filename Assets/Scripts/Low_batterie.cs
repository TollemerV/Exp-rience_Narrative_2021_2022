using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class Low_batterie : MonoBehaviour
{
    public RawImage img;
    private bool show_warn;
    private Timer _timer;
    public void Main()
    {
        show_warn = false;
        _timer = new System.Timers.Timer();
        _timer.Interval = 1000;

        _timer.Elapsed += OnTimedEvent;

        _timer.AutoReset = true;

        _timer.Start();
        print("OK");

    }

    private void OnTimedEvent(System.Object source, System.Timers.ElapsedEventArgs e)
    {
        if (show_warn == true)
        {
            print("here1");
            img.enabled = true;
            _timer.Stop();
            _timer.Interval = 2000; //Set your new interval here
            _timer.Start();
            show_warn = false;
        }
        else
        {
            print("here2");
            img.enabled = false;
            _timer.Stop();
            _timer.Interval = 1000; //Set your new interval here
            _timer.Start();
            show_warn = true;
        }
       
    }

}