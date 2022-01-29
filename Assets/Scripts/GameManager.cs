using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject title1;
    [SerializeField] private GameObject title2;
    [SerializeField]private GameObject title3;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject retry;
    [SerializeField] private GameObject audiomanager;
    [SerializeField] private GameObject wlakmanager;
    [SerializeField] private GameObject ghostwin;
    [SerializeField]private GameObject ghost;
    [SerializeField]private GameObject win;
    [SerializeField]private GameObject timer;
    private Animator title2_animator;
    // Start is called before the first frame update
    void Start()
    {
        title2_animator = title2.GetComponent<Animator>();
        GameInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        title2_animator.SetTrigger("Play");
        player1.SetActive(true);
        player2.SetActive(true);
        menu.SetActive(false);
        audiomanager.GetComponent<AudioSource>().Play();
        wlakmanager.GetComponent<Walk>().WalkStart();
        timer.GetComponent<Timer>().TimerStart();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        title1.SetActive(false);
        audiomanager.GetComponent<AudioSource>().Stop();
        retry.SetActive(true);
        wlakmanager.GetComponent<Walk>().WalkStop();
        player1.GetComponent<Animator>().SetTrigger("dead");
        player1.GetComponent<InputManager>().enabled = false;
        player2.GetComponent<GhostInputManager>().enabled=false;
        ghostwin.SetActive(true);
    }

    public void GameInit()
    {
        player1.GetComponent<InputManager>().enabled = true;
        player2.GetComponent<GhostInputManager>().enabled = true;
        player1.SetActive(false);
        player2.SetActive(false);
        menu.SetActive(true);
        title1.SetActive(true);
        if(title2_animator.GetCurrentAnimatorStateInfo(0).IsName("Title1_End"))
            title2_animator.SetTrigger("init");
        player1.GetComponent<Animator>().SetTrigger("init");
        retry.SetActive(false);
        title3.SetActive(false);
        ghostwin.SetActive(false);
        win.SetActive(false);
    }

    public void GameVictory()
    {
        title1.SetActive(false);
        audiomanager.GetComponent<AudioSource>().Stop();
        title3.SetActive(true);
        wlakmanager.GetComponent<Walk>().WalkStop();
        player1.GetComponent<Animator>().SetTrigger("dead");
        player1.GetComponent<InputManager>().enabled = false;
        player2.GetComponent<GhostInputManager>().enabled=false;
        win.SetActive(true);
    }
}
