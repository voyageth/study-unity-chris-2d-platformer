using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base on https://www.youtube.com/watch?v=tMXgLBwtsvI&t=0s
public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Starting position for the parallax game object
    Vector2 startingPosition;
    // Start Z value of the parallax game object
    float startingZ;
    // distance tha the camera has moved from the starting position of the parallax object
    Vector2 camMoveSinceStart => (Vector2) cam.transform.position - startingPosition;
    float zDIstanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDIstanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDIstanceFromTarget) / clippingPlane; 

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
