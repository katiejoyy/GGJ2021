using UnityEngine;

public class ParkManager : MonoBehaviour
{
    public GameObject parkPrefab;
    public GameObject dogPrefab;
    public int dogSpawnChance = 10;

    public void CreateParkSegment(Vector3 position)
    {
        GameObject park = Instantiate(parkPrefab, position, Quaternion.identity);
        park.transform.localScale = new Vector3(0, 0, 0);

        if(ShouldSpawnDog())
        {
            SpawnDog(position);
        }
    }

    private bool ShouldSpawnDog()
    {
        int roll = Random.Range(0, 100);
        Debug.Log($"Roll was a {roll}, {((roll < dogSpawnChance) ? "" : "not")} spawning a dog");
        return (roll < dogSpawnChance);
    }

    private void SpawnDog(Vector3 position)
    {
        Vector3 dogPosition = position + new Vector3(0, 3, 15);
        GameObject dog = Instantiate(dogPrefab, dogPosition, Quaternion.identity);
        dog.transform.localScale = new Vector3(0, 0, 0);
    }
}
