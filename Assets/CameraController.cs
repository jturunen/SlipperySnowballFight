using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public bool moveCamera = false;
    public int cameraSteps = 8;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (moveCamera)
        {
            if (cameraSteps == 6)
            {
                moveCameraMethod(new Vector3(0, 15, -5f));
            }
            if (cameraSteps == 5)
            {
                moveCameraMethod(new Vector3(0, 12, -4.3f));
            }
            if (cameraSteps == 4)
            {
                moveCameraMethod(new Vector3(0, 10, -3.5f));
            }
            if (cameraSteps == 3)
            {
                moveCameraMethod(new Vector3(0, 7, -2.5f));
            }
            if (cameraSteps == 2)
            {
                moveCameraMethod(new Vector3(0, 5, -1.6f));
            }
            if (cameraSteps == 1)
            {
                moveCameraMethod(new Vector3(0, 2, -0.7f));
            }
        }
    }

    public void moveCameraMethod(Vector3 cameraPosition)
    {
        transform.position = Vector3.Lerp(this.transform.position, cameraPosition, 0.02f);
    }
}
