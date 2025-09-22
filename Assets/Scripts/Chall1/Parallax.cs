using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform; // The camera that follows the player
    [SerializeField] private float parallaxEffect; // How much the layer moves (0 = still, 1 = same as the camera)

    private Vector3 lastCameraPosition;
    private Renderer rend;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;

        // Get Renderer (SpriteRenderer, MeshRenderer, etc.)
        rend = GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        // Check if object is in view (cam)
        if (rend != null && !rend.isVisible)
            return;

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        //Choose one
        //Movement in x only
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, 0, 0);
        //Movement in both x and y
        //transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, 0);
        lastCameraPosition = cameraTransform.position;
    }
}