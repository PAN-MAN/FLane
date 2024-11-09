using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRepeat : MonoBehaviour
{
    Material material;
    Vector2 offset;
    public float Xvelocity,Yvelocity;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        //offset = new Vector2(Xvelocity, Yvelocity);
    }

    // Update is called once per frame
    void Update()
    {
        // Define the minimum and maximum values for the scrolling speed
        float minSpeed = 0.1f; // Adjust these values as needed
        float maxSpeed = 2.0f;

        // Clamp the velocity values
        Xvelocity = Mathf.Clamp(Xvelocity, minSpeed, maxSpeed);
        //Yvelocity = Mathf.Clamp(Yvelocity, minSpeed, maxSpeed);

        // Update the offset with the clamped velocities
        offset = new Vector2(Xvelocity, Yvelocity);
        material.mainTextureOffset += offset * Time.deltaTime;
    }

}
