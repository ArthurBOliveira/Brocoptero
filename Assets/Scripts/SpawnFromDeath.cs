using UnityEngine;
using System.Collections;

public class SpawnFromDeath : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int rate;

    void OnDisable()
    {
        int RnG = Random.Range(0, 101);

        if (RnG <= rate)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}