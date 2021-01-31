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
        float timeThroughAnim = 0;
        Vector3 firstEndPoint = endScale + (extraScale * (scaleBackDuration > 0 ? 1 : 0));
        while (timeThroughAnim <= 1)
        {
            timeThroughAnim = (Time.time - startTime) / firstDuration;
            transform.localScale = Vector3.Slerp(startScale, firstEndPoint, Mathf.Min(1, timeThroughAnim));
            yield return new WaitForFixedUpdate();
        }

        if (scaleBackDuration > 0)
        {
            startTime = Time.time;
            timeThroughAnim = 0;
            while (timeThroughAnim <= 1)
            {
                timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
                transform.localScale = Vector3.Slerp(firstEndPoint, endScale, Mathf.Min(1, timeThroughAnim));
                yield return new WaitForFixedUpdate();
            }
        }
        
        transform.localScale = endScale;
    }
}
