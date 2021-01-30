using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkTriggerEnabler : MonoBehaviour
{
    private Vector3 center;

    public GameObject NorthTrigger;
    public GameObject SouthTrigger;
    public GameObject EastTrigger;
    public GameObject WestTrigger;

    private readonly float distance = 25.0f;

    private void Start()
    {
        center = transform.position + new Vector3(0, 0, 15);
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(center, transform.TransformDirection(transform.forward), out RaycastHit hitInfo, distance))
        {
            NorthTrigger.SetActive(false);
        }

        if (Physics.Raycast(center, transform.TransformDirection(-transform.forward), out RaycastHit hitInfoS, distance))
        {
            SouthTrigger.SetActive(false);
        }
        if (Physics.Raycast(center, transform.TransformDirection(transform.right), out RaycastHit hitInfoE, distance))
        {
            EastTrigger.SetActive(false);
        }
        if (Physics.Raycast(center, transform.TransformDirection(-transform.right), out RaycastHit hitInfoW, distance))
        {
            WestTrigger.SetActive(false);
        }
    }
}
