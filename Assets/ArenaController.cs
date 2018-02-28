using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour {

    public float resizeRate = 0.5F;
    private float nextResize = 0.0F;
    public float resizeSpeed = 0.1F;
    public float sizeReduction = 0.3f;

    public float minSize = 0.2F;

    public float stepRate = 5.0F;
    private float nextStep = 1.0F;

    bool reducingActive = false;

    float reducedX = 0;
    float reducedY = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {

        if (Time.time > nextStep)
        {
            nextStep = Time.time + stepRate;
            reducedX = transform.localScale.x - sizeReduction;
            reducedY = transform.localScale.x - sizeReduction;
            reducingActive = true;
        }

        if (reducingActive)
        {
            resizePlane(resizeSpeed, resizeRate, reducedX, reducedY);
        }

    }

    void resizePlane(float currentResizeSpeed, float currentResizeRate, float reducedX, float reducedY)
    {
        if (Time.time > nextResize && transform.localScale.x >= reducedX && transform.localScale.z >= reducedY && reducedX > minSize)
        {
            nextResize = Time.time + currentResizeRate;
            transform.localScale -= new Vector3(currentResizeSpeed, 0, currentResizeSpeed);
        } else
        {
            reducingActive = false;
        }
    }

}
