using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    private float totalDuration = 0.8f;
    private float scaleBackDuration = 0; // 0.05f;
    private Vector3 startScale;
    private readonly Vector3 endScale = new Vector3(1, 1, 1);
    private readonly Vector3 midScale = new Vector3(1.2f, 1.2f, 1.2f);
    private float startTime;

    void Start()
    {
        startScale = transform.localScale;
        startTime = Time.time;

        StartCoroutine(IncreaseScale());
    }

    IEnumerator IncreaseScale()
    {
        float duration = totalDuration - scaleBackDuration;
        float timeThroughAnim = (Time.time - startTime)/duration;
        while(timeThroughAnim <= 1)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, timeThroughAnim);
            yield return new WaitForFixedUpdate();
            timeThroughAnim = (Time.time - startTime) / duration;
        }

        startTime = Time.time;
        timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
        while (timeThroughAnim <= 1)
        {
            transform.localScale = Vector3.Lerp(midScale, endScale, timeThroughAnim);
            yield return new WaitForFixedUpdate();
            timeThroughAnim = (Time.time - startTime) / scaleBackDuration;
        }

        transform.localScale = endScale;
    }
}
