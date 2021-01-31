using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float firstDuration = 0.5f;
    public float scaleBackDuration = 0;
    private Vector3 startScale;
    public Vector3 endScale = new Vector3(1, 1, 1);
    public Vector3 extraScale = new Vector3(0.2f, 0.2f, 0.2f);
    private float startTime;

    void Start()
    {
        startScale = transform.localScale;
        startTime = Time.time;

        if(startScale != endScale)
        {
            StartCoroutine(IncreaseScale());
        }
    }

    IEnumerator IncreaseScale()
    {
        float timeThroughAnim = (Time.time - startTime)/firstDuration;
        Vector3 firstEndPoint = endScale + extraScale;
        while(timeThroughAnim <= 1)
        {
            transform.localScale = Vector3.Slerp(startScale, firstEndPoint, timeThroughAnim);
            yield return new WaitForFixedUpdate();
            timeThroughAnim = (Time.time - startTime) / firstDuration;
        }

        if (scaleBackDuration > 0)
        {
            startTime = Time.time;
            timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
            while (timeThroughAnim <= 1)
            {
                transform.localScale = Vector3.Slerp(firstEndPoint, endScale, timeThroughAnim);
                yield return new WaitForFixedUpdate();
                timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
            }
        }
        
        transform.localScale = endScale;
    }
}
