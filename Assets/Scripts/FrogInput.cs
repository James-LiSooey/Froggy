using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventManager.RaisePlayerInput(InputType.Tap, MovementDirection.Forward);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            EventManager.RaisePlayerInput(InputType.Swipe, MovementDirection.Right);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EventManager.RaisePlayerInput(InputType.Swipe, MovementDirection.Left);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventManager.RaisePlayerInput(InputType.Swipe, MovementDirection.Backward);
        }

        if (Input.GetMouseButtonUp(0))
        {
            EventManager.RaisePlayerInput(InputType.Drag, MovementDirection.Leap);
        }

    }
        
}
