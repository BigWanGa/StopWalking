using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject walkmanager;
    [SerializeField] private GameObject timer;
    public bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            bar.SetActive(true);
            walkmanager.GetComponent<Walk>().WalkStop();
            isWalking = false;
            timer.GetComponent<Timer>().TimerParse();
        }
        else
        {
            bar.GetComponent<BarController>().InitSelf();
            bar.SetActive(false);
            walkmanager.GetComponent<Walk>().WalkStart();
            isWalking = true;
            timer.GetComponent<Timer>().TimerStart();
        }
    }
    
}
