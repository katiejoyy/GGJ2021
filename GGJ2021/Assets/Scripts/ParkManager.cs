using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkManager : MonoBehaviour
{
    public GameObject parkPrefab;

    public void CreateParkSegment(Vector3 position)
    {
        GameObject park = Instantiate(parkPrefab, position, Quaternion.identity);
        park.transform.localScale = new Vector3(0, 0, 0);
    }
}
