using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToPoint : MonoBehaviour
{
    public float firstDuration = 0.5f;
    public float scaleBackDuration = 0;
    private Vector3 startPosition;
    public Vector3 endPosition = new Vector3(1, 1, 1);
    public Vector3 extraMovement = new Vector3(0.2f, 0.2f, 0.2f);
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;

        if(startPosition != endPosition)
        {
            StartCoroutine(MoveToPoint());
        }
    }

    IEnumerator MoveToPoint()
    {
        float timeThroughAnim = (Time.time - startTime) / firstDuration;
        Vector3 firstEndPoint = endPosition + extraMovement;
        while (timeThroughAnim <= 1)
        {
            transform.position = Vector3.Slerp(startPosition, firstEndPoint, timeThroughAnim);
            yield return new WaitForFixedUpdate();
            timeThroughAnim = (Time.time - startTime) / firstDuration;
        }

        if(scaleBackDuration > 0)
        {
            startTime = Time.time;
            timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
            while (timeThroughAnim <= 1)
            {
                transform.position = Vector3.Slerp(firstEndPoint, endPosition, timeThroughAnim);
                yield return new WaitForFixedUpdate();
                timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
            }
        }

        transform.position = endPosition;
    }
}
