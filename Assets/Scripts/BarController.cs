using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject gameManager;
    [SerializeField] public float time = 1.0f;
    [SerializeField] private float time_ramine;
    private float x_scale_ori;
    private float y_scale_ori;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        InitSelf();
        x_scale_ori = bar.transform.localScale.x;
        y_scale_ori = bar.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        time_ramine -= Time.deltaTime;
        bar.GetComponent<Transform>().localScale = new Vector3(x_scale_ori * time_ramine / time, y_scale_ori, 1);
        bar.GetComponent<SpriteRenderer>().color = new Color(1, time_ramine / time, time_ramine / time);
        if(time_ramine < 0)
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }

    public void InitSelf()
    {
        time_ramine = time;
        
    }

}
