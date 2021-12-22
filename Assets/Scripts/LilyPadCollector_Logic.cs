using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyPadCollector_Logic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LilyPad"))
        {
            Destroy(other.gameObject);
        }
    }
}
