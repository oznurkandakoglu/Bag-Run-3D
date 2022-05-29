using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;

    public float xMin = -28f, xMax = 26f;

    private Camera cam;
    public static Movement instance;

    void Start()
    {

        cam = Camera.main;
    }


    public void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
    }

    public void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        //(Mathf.Clamp(transform.position.x, -10f, 10f), 0, 0);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject firstCube = CoffeeRush.instance.cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;
           

            //Time.deltaTime * swipeSpeed
            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);

            //sınırlandırmak için burayı ekledik
            var pos = firstCube.transform.localPosition;
            pos.x = Mathf.Clamp(pos.x, -27, 26);
            firstCube.transform.localPosition = pos;

        }



    }
}
