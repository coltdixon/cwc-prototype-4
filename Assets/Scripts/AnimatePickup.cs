using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePickup : MonoBehaviour
{
    public float speed = 0.5f;
    public float height = 0.4f;

    private Vector3 startPoint;

    private void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = Mathf.PingPong(Time.time * speed, height);

        transform.position = new Vector3(startPoint.x, startPoint.y + yPos, startPoint.z);
        transform.Rotate(Vector3.up * speed);
    }
}
