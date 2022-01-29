using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInputManager : MonoBehaviour
{
    [SerializeField] private GameObject gamemanager;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject player1;
    [SerializeField] private float distance=10.0f;
    [SerializeField] private float percent = 0.0f;
    [SerializeField] private float time = 5.0f;
    [SerializeField] private float current_time = 0.0f;
    [SerializeField] private Vector3 targetPos = new Vector3(-3.87f, -2.51f, 1);
    
    private Vector3 oriPos;
    // Start is called before the first frame update
    void Start()
    {
        oriPos=ghost.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {

            ghost.SetActive(true);
            if (current_time / time >= 1.0f)
            {
                gamemanager.GetComponent<GameManager>().GameOver();
            }else
            {
                if(player1.GetComponent<InputManager>().isWalking)
                    current_time += Time.deltaTime;
            }
        }
        else
        {
            ghost.SetActive(false);
            if (current_time >= 0.0f)
            {
                current_time -= Time.deltaTime;
            }
            else
            {
                
            }
        }
        ghost.transform.position = oriPos + targetPos * current_time / time;
    }
}
