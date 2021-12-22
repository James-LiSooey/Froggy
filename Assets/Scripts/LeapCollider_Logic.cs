using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapCollider_Logic : MonoBehaviour
{
    public bool dragStarted = false;
    public Vector3 dragStartPosition;
    public Vector3 dragEndPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 colliderStartPosition;
    public Transform colliderResetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //colliderResetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragStarted)
        {
            transform.position = colliderResetPosition.position;
        }
        //colliderResetPosition.position = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if (!dragStarted)
            {
                dragStartPosition = Input.mousePosition;
                colliderStartPosition = transform.position;
                dragStarted = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("StartPos: " + dragStartPosition + ", CurrentPos: " + dragCurrentPosition);
            dragCurrentPosition = Input.mousePosition;
            float xPositionSign = Mathf.Sign(dragCurrentPosition.x - dragStartPosition.x);
            float yPositionSign = Mathf.Sign(dragCurrentPosition.y - dragStartPosition.y);
            if (yPositionSign > 0)
            {
                yPositionSign = 0;
            }

            transform.position = new Vector3(colliderStartPosition.x + (xPositionSign*Mathf.Pow((dragCurrentPosition.x - dragStartPosition.x) * .01f,2f)), colliderStartPosition.y, colliderStartPosition.z + (yPositionSign*Mathf.Pow((dragCurrentPosition.y - dragStartPosition.y) * .01f,2f)));
        }
    }
    public void ResetPosition()
    {
        dragStarted = false;
    }

}
