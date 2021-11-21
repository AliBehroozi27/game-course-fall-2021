using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private GameManager gameManager;

    public Vector2 upForce = new Vector2(0, 1);
    public double ForceLimit = 0.1;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPuased)
        {
            this.gameObject.SetActive(false);
            rigidbody.velocity = new Vector2(0, 0);
            return;
        }

        upForce = new Vector2(0, gameManager.VerticalMovemetOffset);
        Debug.Log(gameManager.VerticalMovemetOffset);
        if (Input.GetKeyDown(KeyCode.Space) && rigidbody.velocity.y < ForceLimit)
        {
            rigidbody.AddForce(upForce);
        }
    }
    public void reset()
    {
        this.gameObject.SetActive(true);
        rigidbody.transform.position = new Vector3(0f, 0f);
        rigidbody.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.isPuased)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Mane") || collision.gameObject.CompareTag("DeathZone"))
        {
            gameManager.onTouchedManeOrDeathZone();
        }

        if (collision.gameObject.CompareTag("Space"))
        {
            gameManager.onPassedMane();
        }
    }
}
