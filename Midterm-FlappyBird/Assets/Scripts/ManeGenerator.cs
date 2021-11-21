using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ManePrefab;
    private GameManager gameManager;
    private float timeTillNextMane = 0;
    public float ManeIntervalTime = 2;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ManeIntervalTime = (1 / gameManager.HorizontalMovemetOffset) / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPuased)
        {
            timeTillNextMane = 0;
            return;
        }


        timeTillNextMane -= Time.deltaTime;
        if(timeTillNextMane <= 0)
        {
            Instantiate(ManePrefab, new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Random.Range(-0.6f, 0.6f) * Camera.main.orthographicSize), ManePrefab.transform.rotation);
            timeTillNextMane = ManeIntervalTime;
        }
    }
}
