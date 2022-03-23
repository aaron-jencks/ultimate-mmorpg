using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 1)]
    public float smootingTime;

    public Transform playerTransform;

    private Transform ctransform;

    private void Start() {
        ctransform = GetComponent<Transform>();
    }

    public void FixedUpdate() {
        Vector3 pos = GetComponent<Transform>().position;

        pos.x = Mathf.Lerp(pos.x, playerTransform.position.x, smootingTime);
        pos.y = Mathf.Lerp(pos.y, playerTransform.position.y, smootingTime);

        GetComponent<Transform>().position = pos;
    }
}
