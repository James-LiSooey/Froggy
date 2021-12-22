using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Logic : MonoBehaviour
{
    public Material defaultMat;
    public Material triggerMat;
    private Renderer colliderRenderer;

    public bool collisionDetected = false;
    private Transform collisionTransform;


    // Start is called before the first frame update
    void Start()
    {
        //Get the Renderer component from the new cube
        colliderRenderer = gameObject.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Transform GetCollisionTransform()
    {
        if (collisionDetected && collisionTransform)
        {
            return collisionTransform;
        }
        else
        {
            return null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Collider Trigger");
        colliderRenderer.material = triggerMat;
        collisionDetected = true;
        collisionTransform = other.transform;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collider Trigger");
        colliderRenderer.material = triggerMat;
        collisionDetected = true;
        collisionTransform = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
      //  Debug.Log("Collider Trigger");
        colliderRenderer.material = defaultMat;
        collisionDetected = false;
        collisionTransform = null;
    }
}
