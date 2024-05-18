using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactersprite : MonoBehaviour
{
      public float xBorder = 110f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localScale;
         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x <= xBorder) 
         {
            characterScale.x = 10;
         }
        
        
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -xBorder) 
        {
            characterScale.x = -10;
        }

    transform.localScale = characterScale;
    }
}
