using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkSpawner : MonoBehaviour
{
    public GameObject spawnPoint;

    private ParkManager parkManager;

    private void Start()
    {
        parkManager = GameObject.Find("ParkManager").GetComponent<ParkManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        parkManager.CreateParkSegment(spawnPoint.transform.position);
        gameObject.SetActive(false);
    }
}
