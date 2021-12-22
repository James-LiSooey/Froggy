using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public AnimationCurve leapCurve;

    public float sphereCastRadius = .1f;
    public float maxTapDistance = 1f;
    public float maxSwipeDistance = .5f;
    public Transform frogTransform;

    public Transform floatObject;
    public bool floatingOnObject = false;

    public Collider_Logic colliderLeft;
    public Collider_Logic colliderRight;
    public Collider_Logic colliderForward;
    public Collider_Logic colliderBackward;
    public Collider_Logic colliderLeap;
    public LeapCollider_Logic leapColliderLogic;

    private float leapTime = 0f;
    public bool leaping = false;
    public float leapModifier = .1f;
    private float movementRangeX = 0;
    private float movementRangeZ = 0;

    private float leapStartX = 0;
    private float leapStartZ = 0;




    // Start is called before the first frame update
    void Start()
    {
        frogTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        EventManager.playerInput += PlayerInput;
        
    }

    private void LateUpdate()
    {
        //if (floatObject)
        //{
        //    floatingOnObject = false;
        //}



        //if floating keep frog attached to the object
        /*
        if(floatingOnObject)
        {
            frogTransform.position = floatObject.position + new Vector3(0,1f,0);
        }
        */
        
         
        if (leaping)
        {
            frogTransform.position = Vector3.Lerp(frogTransform.position, floatObject.position + new Vector3(0, 1f, 0), leapModifier);
            if (Vector3.Distance(frogTransform.position, floatObject.position + new Vector3(0, 1f, 0)) < .1f)
            {
                leapTime = 0;
                leaping = false;
            }
        }
        else
        {
            if (floatingOnObject)
            {
                frogTransform.position = floatObject.position + new Vector3(0, 1f, 0);
            }

        }
        

        //AnimationCurve leap code
        #region
        /*
         
        if (leaping)
        {

            print("Movement Range" + movementRangeZ);

            float leapXValue = leapCurve.Evaluate(leapTime);
            float leapXPos = leapStartX + movementRangeX * leapCurve.Evaluate(leapTime);
            float leapZValue = leapCurve.Evaluate(leapTime);
            float leapZPos = leapStartZ + movementRangeZ * leapCurve.Evaluate(leapTime);
            frogTransform.position = new Vector3(leapXPos, 1f, leapZPos);

            print(leapCurve.Evaluate(leapTime));
                print(leapZPos);
            leapTime += leapModifier;

            if (leapTime > 1f)
            {
                leapTime = 0;
                leaping = false;
            }
        }
        else
        {
            if (floatingOnObject)
            {
                frogTransform.position = floatObject.position + new Vector3(0, 1f, 0);
            }
            
        }
        */
        #endregion



    }

    private void PlayerInput(InputType inputType, MovementDirection movementDirection)
    {
        switch (inputType)
        {
            case InputType.Tap:
                Debug.Log("Tap");
                Hop(movementDirection);
                break;
            case InputType.Swipe:
                Debug.Log("Swipe");
                Hop(movementDirection);
                break;
            case InputType.Drag:
                Debug.Log("Drag");
                Leap();
                break;
            default:
                Debug.Log("Input with no matching type");
                break;
        }
    }

    private void Leap()
    {
        Transform colliderTransform  = colliderLeap.GetCollisionTransform();
        if (colliderTransform)
        {
            if (colliderTransform.CompareTag("LilyPad"))
            {
                floatObject = colliderTransform;
                floatingOnObject = true;
                leaping = true;

                //AnimationCurve leap code
                #region
                /*
                leapStartX = frogTransform.position.x;
                leapStartZ = frogTransform.position.z;

                movementRangeX = floatObject.position.x - frogTransform.position.x;
                movementRangeZ = floatObject.position.z - frogTransform.position.z;
                */
                #endregion
            }
        }

        leapColliderLogic.ResetPosition();
    }

        private void Hop(MovementDirection movementDirection)
    {
        Transform colliderTransform;
        switch (movementDirection)
        {
            case MovementDirection.Forward:
                Debug.Log("Tap");
                colliderTransform = colliderForward.GetCollisionTransform();
                break;
            case MovementDirection.Left:
                colliderTransform = colliderLeft.GetCollisionTransform();
                break;
            case MovementDirection.Right:
                colliderTransform = colliderRight.GetCollisionTransform();
                break;
            case MovementDirection.Backward:
                colliderTransform = colliderBackward.GetCollisionTransform();
                break;
            default:
                Debug.Log("Input with no matching type");
                return;
        }

        if (colliderTransform.CompareTag("LilyPad"))
        {
            floatObject = colliderTransform;
            //frogTransform.position = floatObject.position;

            floatingOnObject = true;
        }
    }
}
