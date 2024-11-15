using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScreen : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Object.Destroy(gameObject);
            Debug.Log("Pipe Destoried");
        }
    }
}
