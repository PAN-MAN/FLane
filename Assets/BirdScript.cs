using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public float upflap, downflap;
    public LogicScript logic;
    public bool BirdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && BirdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        // Rotate the bird based on its velocity (for a diving or lifting effect)
        if (BirdIsAlive)
        {
            float angle = Mathf.Clamp(myRigidbody.velocity.y * 5, downflap, upflap);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        BirdIsAlive = false;
    }
}
