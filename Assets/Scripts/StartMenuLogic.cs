using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuLogic : MonoBehaviour
{

    public GameObject StartMenuCanvas;

    private void OnEnable()
    {
        EventManager.pressedPlay += StartRun;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PressPlay()
    {
        EventManager.RaisePressedPlay();
    }

    public void PressOptions()
    {
       // EventManager.RaisePressedPlay();
    }

    public void PressScore()
    {
      //  EventManager.RaisePressedPlay();
    }

    private void StartRun()
    {
        if (StartMenuCanvas)
        {
            StartMenuCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
