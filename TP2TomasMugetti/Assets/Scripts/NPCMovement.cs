using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPhysics;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    void FixedUpdate()
    {
        MugettiPhysics.MVec2 speeds;
        speeds.X = 0;
        speeds.Y = speed * -1;
        MugettiPhysics.MVec2 vecZero;
        vecZero.X = 0;
        vecZero.Y = 0;

        MugettiPhysics.MVec2 movement = MugettiPhysics.MRU(0,Time.deltaTime,vecZero,speeds);
        Vector3 newPos = transform.position;
        newPos.y += movement.Y;
        transform.position = newPos;
    }
}
