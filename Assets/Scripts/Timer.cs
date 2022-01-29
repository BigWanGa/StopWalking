using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]private float time=20.0f;
    [SerializeField]private GameObject gamemanager;
    [SerializeField] private float time_remain;
    [SerializeField] private bool isTimer=false;
    // Start is called before the first frame update
    void Start()
    {
        TimerInit();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimer){
            if(time_remain>0.0f)
            {
                time_remain-=Time.deltaTime;
            }
            else
            {
                gamemanager.GetComponent<GameManager>().GameVictory();
            }
        }
        else
        {
            if(time_remain<time)
            {
                time_remain+=Time.deltaTime;
            }
        }
        this.GetComponent<Image>().fillAmount=1-time_remain/time;
    }

    public void TimerStart()
    {
        isTimer=true;
    }

    public void TimerParse()
    {
        isTimer=false;
    }

    public void TimerInit()
    {
        time_remain=time;
    }
}
