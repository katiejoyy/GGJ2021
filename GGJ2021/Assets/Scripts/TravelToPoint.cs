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
        float timeThroughAnim = 0;
        Vector3 firstEndPoint = endPosition + (extraMovement * (scaleBackDuration>0 ? 1 : 0));
        while (timeThroughAnim <= 1)
        {
            timeThroughAnim = (Time.time - startTime) / firstDuration;
            transform.position = Vector3.Slerp(startPosition, firstEndPoint, Mathf.Min(1, timeThroughAnim));
            yield return new WaitForFixedUpdate();
        }

        if(scaleBackDuration > 0)
        {
            startTime = Time.time;
            timeThroughAnim = 0;
            while (timeThroughAnim <= 1)
            {
                timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
                transform.position = Vector3.Slerp(firstEndPoint, endPosition, Mathf.Min(1, timeThroughAnim));
                yield return new WaitForFixedUpdate();
            }
        }

        transform.position = endPosition;
    }
}
