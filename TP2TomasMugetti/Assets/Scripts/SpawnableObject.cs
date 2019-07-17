using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    [SerializeField] Transform limit;
    private bool available;
    // Start is called before the first frame update
    void Start()
    {
        available = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position.y <= limit.position.y){ 
            available = true;
            gameObject.SetActive(false);
        }
    }
    public bool IsAvailable(){return available;}
    public void Spawn(Vector3 position){
        available = false;
        transform.position = position;
        gameObject.SetActive(true);
    }
}
