using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject[] chickenObj;
    public Transform[] chickenPos;

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    Player worker;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "App")
        {
            StartCoroutine(OnPush());
            Cook();
        }
    }

    IEnumerator OnPush()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        mat.color = Color.white;
    }

    public void Cook()
    {
            Vector3 ranVec = Vector3.right * Random.Range(-3, 3)
                + Vector3.forward * Random.Range(-3, 3);
            Instantiate(chickenObj[0], chickenPos[0].position + ranVec, chickenPos[0].rotation);
    }

}
