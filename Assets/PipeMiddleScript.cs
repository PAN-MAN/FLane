using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is on the "Bird" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bird"))
        {
            logic.addScore(1); // Increment the score by 1
        }
    }

}
