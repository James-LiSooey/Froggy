using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLilyPad_Logic : LilyPad_Logic
{
    public float initialSpeed = 10f;

    private void OnEnable()
    {
        EventManager.pressedPlay += StartRun;
    }

    private void OnDisable()
    {
        EventManager.pressedPlay -= StartRun;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartRun()
    {
        speed = initialSpeed;
    }
}
