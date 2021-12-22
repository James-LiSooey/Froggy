using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InputType
{
    Tap,
    Swipe,
    Drag,
}

public enum MovementDirection
{
    Forward,
    Left,
    Right,
    Backward,
    Leap,
}


public enum GameState
{
    MENU,
    PLAY,
    DEAD,
}


public class EventManager : MonoBehaviour
{
    public delegate void PlayerInput(InputType inputType, MovementDirection movementDirection);
    public static event PlayerInput playerInput;

    public delegate void PressedPlay();
    public static event PressedPlay pressedPlay;

    public static void RaisePressedPlay()
    {
        if (pressedPlay != null)
        {
            pressedPlay();
        }
    }

        public static void RaisePlayerInput(InputType inputType, MovementDirection movementDirection)
    {
        if (playerInput != null)
        {
            playerInput(inputType, movementDirection);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
