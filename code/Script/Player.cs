using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public GameObject[] gloves;
    public bool[] hasGloves;
    public GameManager manager;

    public int chicken;
    public int friChickenA;
    public int friChickenB;
    public int maxChicken;
    public int maxFriChickenA;
    public int maxFriChickenB;


    float hAxis;
    float vAxis;

    bool interDown;
    bool swapDown;
    bool pushDown;
    bool isPushReady = true;
    bool isFinish = false;

    Vector3 moveVec;

    Animator anim;

    GameObject nearObject;
    Glove equipGlove;
    float pushDelay;
    int equipGloveIndex = -1;


    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        GetInput();
        Move();
        Swap();
        ButPush();
        Interaction();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        pushDown = Input.GetButtonDown("Button");
        interDown = Input.GetButtonDown("Interaction");
        swapDown = Input.GetButtonDown("Swap");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("IsWalk", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }


    void Swap()
    {
        if (swapDown && !hasGloves[0])
            return;

        int gloveIndex = -1;
        if (swapDown) gloveIndex = 0;

        if (swapDown)
        {
            if (equipGlove != null)
                equipGlove.gameObject.SetActive(false);

            equipGloveIndex = gloveIndex;
            equipGlove = gloves[gloveIndex].GetComponent<Glove>();
            equipGlove.gameObject.SetActive(true);
        }

    }

    void ButPush()
    {
        if (equipGlove == null)
            return;

        pushDelay += Time.deltaTime;
        isPushReady = equipGlove.rate < pushDelay; //true

        if (pushDown && isPushReady)
        {
            equipGlove.Use();
            anim.SetTrigger("doPush");
            pushDelay = 0;
        }
    }

    void Interaction()
    {
        if (interDown && nearObject != null)
        {
            if (nearObject.tag == "Glove")
            {
                Tool tool = nearObject.GetComponent<Tool>();
                int gloveIndex = tool.value;
                hasGloves[gloveIndex] = true;

                Destroy(nearObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tool")
        {
            Tool tool = other.GetComponent<Tool>();
            switch (tool.type)
            {
                case Tool.Type.Chicken:
                    chicken += tool.value;
                    if (chicken > maxChicken)
                        chicken = maxChicken;
                    break;
                case Tool.Type.FriChickenA:
                    friChickenA += tool.value;
                    if (friChickenA > maxFriChickenA)
                        friChickenA = maxFriChickenA;
                    if (chicken > 0)
                        chicken -= 1;
                    Destroy(other.gameObject);
                        break;
                case Tool.Type.FriChickenB:
                    friChickenB += tool.value;
                    if (friChickenB > maxFriChickenB)
                        friChickenB = maxFriChickenB;
                    if (chicken > 0)
                        chicken -= 1;
                    Destroy(other.gameObject);
                    break;
            }
        }
        if (friChickenA == maxFriChickenA && friChickenB == maxFriChickenB && !isFinish)
        {
            OnFinish();
        }
    }

    void OnFinish()
    {
        isFinish = true;
        manager.GameOver();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Glove")
            nearObject = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Glove")
            nearObject = null;
    }


}
