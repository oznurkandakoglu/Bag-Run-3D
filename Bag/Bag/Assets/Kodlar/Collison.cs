using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Collison : MonoBehaviour
{
    //public List<GameObject> cubes = new List<GameObject>();

    public float speed = 5.0f;

    //int count = CoffeeRush.instance.cubes.Count;

    public IEnumerator WaitSec()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Cube")
        {
            //PlayerData.Data1 = 5;

            if (!CoffeeRush.instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collison>();

                CoffeeRush.instance.StackCube(other.gameObject, CoffeeRush.instance.cubes.Count - 1);
            }
        }

        if (other.tag == "Cube2")
        {
            if (!CoffeeRush.instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collison>();

                CoffeeRush.instance.StackCube2(other.gameObject, CoffeeRush.instance.cubes.Count - 1);
            }
        }

        if (other.tag == "Obstacle")
        {
            CoffeeRush.instance.LeaveAndDestroyCube(gameObject, CoffeeRush.instance.cubes.Count);

            if (CoffeeRush.instance.cubes.Count == 1)
            {
                UIManager.gameOver = true;
            }

        }

        if (other.tag == "Obstacle2")
        {
            CoffeeRush.instance.LeaveCube(gameObject, CoffeeRush.instance.cubes.Count);

            int m = 30;
            int n = 80;

            int k = -15;
            int j = 15;

            int randomX = UnityEngine.Random.Range(k, j);
            int randomZ = UnityEngine.Random.Range(m, n);

            for (int i = 0; i < CoffeeRush.instance.cubes.Count; i++)
            {
                k = 10;
                j = 26;
                randomX = UnityEngine.Random.Range(k, j);
                k -= 5;
                j -= 5;
            }

            for (int i = 0; i < CoffeeRush.instance.cubes.Count; i++)
            {
                m = 30;
                n = 80;
                randomZ = UnityEngine.Random.Range(m, n);
                m -= 5;
                n -= 5;
            }

            if (gameObject != CoffeeRush.instance.cubes[0])
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.tag = "Cube2";
                gameObject.transform.parent = null;
                Destroy(GetComponent<Collison>());
                gameObject.transform.localPosition += new Vector3(randomX, 0, randomZ);
            }
            else
            {
                gameObject.tag = "Untagged";
                gameObject.transform.localPosition = transform.localPosition;
            }

        }

        if (other.tag == "Obstacle3")
        {
            CoffeeRush.instance.LeaveAndDestroyCube(gameObject, CoffeeRush.instance.cubes.Count);
        }

        if (other.tag == "FinishLine")
        {
            SceneManager.LoadScene(0);
            AnimationUI.nextScene = false;
            //WaitSec();
        }
    }
}