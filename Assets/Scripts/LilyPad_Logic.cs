using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyPad_Logic : MonoBehaviour
{
    public float speed = 1f;
    private float speedModifier = .001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed* speedModifier);
    }
}
