using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private bool iswalking = false;
    [SerializeField] private float wide;
    [SerializeField] private float speed;
    [SerializeField] private float distance = 0.0f;
    [SerializeField] private GameObject floor1;
    [SerializeField] private GameObject floor2;
    [SerializeField] private GameObject player1;
    private GameObject floor3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (iswalking)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            distance += speed * Time.deltaTime;
            if (Mathf.Abs(distance) >= Mathf.Abs(wide))
            {
                floor1.transform.position += new Vector3(wide * 2, 0, 0);
                floor3 = floor1;
                floor1 = floor2;
                floor2 = floor3;
                distance = 0.0f;
            }
        }
    }

    public void WalkStart()
    {
        iswalking = true;
        player1.GetComponent<Animator>().SetBool("isWalk", true);
    }

    public void WalkStop()
    {
        iswalking = false;
        player1.GetComponent<Animator>().SetBool("isWalk", false);
    }    
}
