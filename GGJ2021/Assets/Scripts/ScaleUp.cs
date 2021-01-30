using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    private float duration = 1.0f;
    private Vector3 startScale;
    private readonly Vector3 endScale = new Vector3(1, 1, 1);
    private float startTime;

    void Start()
    {
        startScale = transform.localScale;
        startTime = Time.time;
    }

    void Update()
    {
        float timeThroughAnim = (Time.time - startTime)/duration;

        transform.localScale = Vector3.Lerp(startScale, endScale, timeThroughAnim);
    }
}
