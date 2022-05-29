using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public float moveSpeed;
    public float swipeSpeed;

    public static Animation instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        transform.position += Vector3.left * swipeSpeed * Time.deltaTime;
    }

    public IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animation")
        {
            Time.timeScale = 0;
            WaitSec();
            AnimationUI.nextScene = true;
        }
    }
}
