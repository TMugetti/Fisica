using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnableObject[] Objects;
    [SerializeField] Transform[] SpawnPoints;
    // Update is called once per frame
    void Update()
    {
        foreach(SpawnableObject s in Objects){
            if(s.IsAvailable()){
                int pos = Random.Range(0, SpawnPoints.Length);
                s.Spawn(SpawnPoints[pos].position);
            }
        }
    }
}
