using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkSpawner : MonoBehaviour
{
    /*
     When the player enters the trigger
     Spawn a new piece of ground
    */

    public GameObject spawnPoint;
    public GameObject parkPrefab;

    public void OnTriggerEnter(Collider other)
    {
        GameObject park = Instantiate(parkPrefab, spawnPoint.transform.position, Quaternion.identity);
        park.transform.localScale = new Vector3(0, 0, 0);
    }
}
