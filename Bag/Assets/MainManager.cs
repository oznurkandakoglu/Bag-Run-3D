using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene", 1);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
