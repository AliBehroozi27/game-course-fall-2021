using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mane : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 vel = new Vector3(1, 0);
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPuased)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.position = transform.position - (vel * gameManager.HorizontalMovemetOffset);

        if (transform.position.x < -1 * Camera.main.orthographicSize * Camera.main.aspect)
        {
            Destroy(this.gameObject);
        }
    }
}
