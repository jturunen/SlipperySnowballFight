using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool moveCamera = false;

    public float reducedY = 0;
    public float reducedZ = 0;

    public float zoomSpeed = 0.05f;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        if (moveCamera)
        {
            moveCameraMethod(new Vector3(0, reducedY, reducedZ));         
        }
    }

    public void moveCameraMethod(Vector3 cameraPosition)
    {
        transform.position = Vector3.Lerp(this.transform.position, cameraPosition, 0.002f);
    }
}
