using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPhysics;

public class TankMovement : MonoBehaviour
{
    private float vel = 3;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MugettiPhysics.MVec2 pos;
        MugettiPhysics.MVec2 speeds;
        pos.X = transform.position.x;
        pos.Y = transform.position.y;
        speeds.X = vel * Input.GetAxisRaw("Horizontal");
        speeds.Y = 0;
        var movement = MugettiPhysics.MRU(0, Time.deltaTime,pos,speeds);
        Vector3 newPos = new Vector3(movement.X, movement.Y, transform.position.z);
        transform.position = newPos;
    }
}
