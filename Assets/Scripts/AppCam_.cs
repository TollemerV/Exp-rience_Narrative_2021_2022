using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class AppCam_ : MonoBehaviour
{
    public GameObject panel;
    private Timer _timer;

    private void Awake()
    {
        panel.gameObject.SetActive(false);
    }
    public void Main()
    {
        _timer = new System.Timers.Timer();
        _timer.Interval = 500;

        _timer.Elapsed += OnTimedEvent;

        _timer.AutoReset = true;

        _timer.Start();

    }

    private void OnTimedEvent(System.Object source, System.Timers.ElapsedEventArgs e)
    {
        panel.gameObject.SetActive(true);
        _timer.Stop();
    }

}
