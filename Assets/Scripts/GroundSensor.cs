using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public static bool _isGrounded;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            _isGrounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            _isGrounded = false;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            _isGrounded = true;
        }
    }


    // Update is called once per frame
  
}
