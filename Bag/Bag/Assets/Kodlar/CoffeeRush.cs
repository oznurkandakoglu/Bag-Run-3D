using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using TMPro;

public class CoffeeRush : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Camera cam;



    public static CoffeeRush instance;

    public float movementDelay = 0.25f;

    public List<GameObject> cubes = new List<GameObject>();

    [SerializeField] public TextMeshProUGUI gameText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }


    public void StackCube(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 15;
        other.transform.localPosition = newPos;

        cubes.Add(other);

        StartCoroutine(MakeObjectsBigger());

        PlayerDatas.point++;

        gameText.enabled = true;
        
    }

    public void StackCube2(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 15;
        other.transform.localPosition = newPos;

        cubes.Add(other);

        PlayerDatas.point++;

        
    }


    public IEnumerator MakeObjectsBigger()
    {
        for (int i = cubes.Count - 1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(5, 5, 5);
            scale *= 1.5f;

            cubes[index].transform.DOScale(scale, 0.1f).OnComplete(() => cubes[index].transform.DOScale(new Vector3(15, 15, 15), 0.1f)); // 0.1
            yield return new WaitForSeconds(0.05f); //0.05
        }
    }


    public void MoveListElements()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition; //localPosition
            pos.x = cubes[i - 1].transform.localPosition.x; //pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    public void MoveOrigin()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[0].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, 0.70f); // 0.70
        }
    }

    public void LeaveAndDestroyCube(GameObject other, int index)
    {        
        if (cubes.Count > 1)
        {
            Destroy(cubes[cubes.Count - 1]);
            cubes.RemoveAt(cubes.Count - 1);
            PlayerDatas.point--;
        }
    }

    public void LeaveCube(GameObject other, int index)
    {
        if (cubes.Count > 1)
        {
            //Destroy(cubes[cubes.Count - 1]);
            cubes.RemoveAt(cubes.Count - 1);
            PlayerDatas.point--;
        }
    }
}
