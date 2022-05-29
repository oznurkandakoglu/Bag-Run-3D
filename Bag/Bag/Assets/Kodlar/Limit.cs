using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    
    void Start()
    {

    }


    public void Update()
    {        
        if (transform.localPosition.x > 26 || transform.localPosition.x < -28)
        {
            Debug.Log("höbözöbölöp");
        }
    }
}
