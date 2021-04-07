using System;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float scrollSpeed = 3;

    // background width in pixels / pixels per Unit
    public const float ScrollWidth = 15;

    // Update is called once per frame
    void Update()
    {
        // Getting the current background position
        Vector3 pos = transform.position;

        // Moving the object to the left
        pos.x -= scrollSpeed * Time.deltaTime;

        // Check if the object is completely off the screen
        if (transform.position.x < -ScrollWidth)
        {
            Offscreen(ref pos);
        }

        // Updating the position to the new place
        transform.position = pos;
    }

    protected virtual void Offscreen(ref Vector3 pos)
    {
        pos.x += 2 * ScrollWidth;
    }
}